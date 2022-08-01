using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EcommerceWebApp.Models;
using EcommerceWebApp.Helper;
using EcommerceWebApp.Extension;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace EcommerceWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminAccountsController : Controller
    {
        private readonly EcommerceShopContext _context;

        public INotyfService _inotyfService { get; }
        public AdminAccountsController(EcommerceShopContext context, INotyfService inotyfService)
        {
            _context = context;
            _inotyfService = inotyfService;
        }

        public bool ValidatePhone(string phone)
        {
            try
            {
                var customer = _context.Customers.AsNoTracking().SingleOrDefault(x => x.Phone.ToLower() == phone);
                if (customer != null)
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return true;
            }
        }

        public bool ValidateEmail(string email)
        {
            try
            {
                var customer = _context.Customers.AsNoTracking().SingleOrDefault(x => x.Email == email);
                if (customer != null)
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return true;
            }
        }

        // GET: Admin/AdminAccounts
        public async Task<IActionResult> Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Accounts");
            }
            ViewData["Role"] = new SelectList(_context.Roles, "RoleId", "Description");
            ViewData["Status"] = new List<SelectListItem>()
            {
                new SelectListItem(){Text="Active", Value="1"},
                new SelectListItem(){Text="Block", Value="0"}
            };
            var ecommerceShopContext = _context.Accounts.Include(a => a.Role);
            return View(await ecommerceShopContext.ToListAsync());
        }

        // GET: Admin/AdminAccounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts
                .Include(a => a.Role)
                .FirstOrDefaultAsync(m => m.AccountId == id);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // GET: Admin/AdminAccounts/Create
        public IActionResult Create()
        {
            ViewData["Role"] = new SelectList(_context.Roles, "RoleId", "RoleName");
            return View();
        }

        // POST: Admin/AdminAccounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AccountId,Phone,Email,Password,Salt,Active,FullName,RoleId,LastLogin,CreateDate")] Account account)
        {
            if (!ValidateEmail(account.Email))
            {
                ModelState.AddModelError("Email", $"Email {account.Email} is used");
            }
            if (!ValidatePhone(account.Phone))
            {
                ModelState.AddModelError("Phone", $"Phone {account.Phone} is used");
            }
            if (ModelState.IsValid)
            {
                string salt = Utilities.GetRandomKey();
                account.Salt = salt;
                account.Password = (account.Password + salt.Trim()).ToMD5();
                account.CreateDate = DateTime.Now;
                _context.Add(account);
                await _context.SaveChangesAsync();
                _inotyfService.Success("Create success");
                return RedirectToAction(nameof(Index));
            }
            ViewData["Role"] = new SelectList(_context.Roles, "RoleId", "RoleName", account.RoleId);
            return View(account);
        }

        // GET: Admin/AdminAccounts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }
            ViewData["Role"] = new SelectList(_context.Roles, "RoleId", "RoleName", account.RoleId);
            return View(account);
        }

        // POST: Admin/AdminAccounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AccountId,Phone,Email,Password,Salt,Active,FullName,RoleId,LastLogin,CreateDate")] Account account)
        {
            if (id != account.AccountId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(account);
                    await _context.SaveChangesAsync();
                    _inotyfService.Success("Edit success");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountExists(account.AccountId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Role"] = new SelectList(_context.Roles, "RoleId", "RoleName", account.RoleId);
            return View(account);
        }

        // GET: Admin/AdminAccounts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts
                .Include(a => a.Role)
                .FirstOrDefaultAsync(m => m.AccountId == id);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // POST: Admin/AdminAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var account = await _context.Accounts.FindAsync(id);
            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();
            _inotyfService.Success("Delete success");
            return RedirectToAction(nameof(Index));
        }

        private bool AccountExists(int id)
        {
            return _context.Accounts.Any(e => e.AccountId == id);
        }
    }
}
