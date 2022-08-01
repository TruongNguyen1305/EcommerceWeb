using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EcommerceWebApp.Models;
using PagedList.Core;
using EcommerceWebApp.Helper;
using System.IO;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace EcommerceWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminPagesController : Controller
    {
        private readonly EcommerceShopContext _context;
        public INotyfService _inotyfService { get; }
        public AdminPagesController(EcommerceShopContext context, INotyfService inotyfService)
        {
            _context = context;
            _inotyfService = inotyfService;
        }

        // GET: Admin/AdminPages
        public async Task<IActionResult> Index(int? page)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Accounts");
            }
            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 20;
            var pagesList = _context.Pages.AsNoTracking().OrderByDescending(x => x.PageId);
            int maxNumPage = (int)Math.Ceiling((double)pagesList.Count() / pageSize);
            if (maxNumPage < pageNumber)
            {
                pageNumber--;
            }
            if (pageNumber == 0)
            {
                pageNumber = 1;
            }
            PagedList<Page> models = new PagedList<Page>(pagesList, pageNumber, pageSize);
            ViewBag.CurrentPage = pageNumber;
            return View(models);
        }

        // GET: Admin/AdminPages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var page = await _context.Pages
                .FirstOrDefaultAsync(m => m.PageId == id);
            if (page == null)
            {
                return NotFound();
            }

            return View(page);
        }

        // GET: Admin/AdminPages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminPages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PageId,PageName,Contents,Thumb,Published,Title,MetaDesc,MetaKey,Alias,CreateAt,Ordering")] Page page, Microsoft.AspNetCore.Http.IFormFile fThumb)
        {
            if (ModelState.IsValid)
            {
                if (fThumb != null)
                {
                    string extension = Path.GetExtension(fThumb.FileName);
                    string image = Utilities.SEOUrl(page.PageName) + extension;
                    page.Thumb = await Utilities.UploadFile(fThumb, @"pages", image.ToLower());
                }
                if (string.IsNullOrEmpty(page.Thumb))
                {
                    page.Thumb = "default.jpg";
                }
                page.CreateAt = DateTime.Now;
                page.Alias = Utilities.SEOUrl(page.PageName);
                _context.Add(page);
                await _context.SaveChangesAsync();
                _inotyfService.Success("Success");
                return RedirectToAction(nameof(Index));
            }
            return View(page);
        }

        // GET: Admin/AdminPages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var page = await _context.Pages.FindAsync(id);
            if (page == null)
            {
                return NotFound();
            }
            return View(page);
        }

        // POST: Admin/AdminPages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PageId,PageName,Contents,Thumb,Published,Title,MetaDesc,MetaKey,Alias,CreateAt,Ordering")] Page page, Microsoft.AspNetCore.Http.IFormFile fThumb)
        {
            if (id != page.PageId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    page.PageName = Utilities.ToTitleCase(page.PageName);
                    if (fThumb != null)
                    {
                        string extension = Path.GetExtension(fThumb.FileName);
                        string image = Utilities.SEOUrl(page.PageName) + extension;
                        page.Thumb = await Utilities.UploadFile(fThumb, @"pages", image.ToLower());
                    }
                    if (string.IsNullOrEmpty(page.Thumb))
                    {
                        page.Thumb = "default.jpg";
                    }
                    page.Alias = Utilities.SEOUrl(page.PageName);
                    _context.Update(page);
                    await _context.SaveChangesAsync();
                    _inotyfService.Success("Success");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PageExists(page.PageId))
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
            return View(page);
        }

        // GET: Admin/AdminPages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var page = await _context.Pages
                .FirstOrDefaultAsync(m => m.PageId == id);
            if (page == null)
            {
                return NotFound();
            }

            return View(page);
        }

        // POST: Admin/AdminPages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var page = await _context.Pages.FindAsync(id);
            _context.Pages.Remove(page);
            await _context.SaveChangesAsync();
            _inotyfService.Success("Success");
            return RedirectToAction(nameof(Index));
        }

        private bool PageExists(int id)
        {
            return _context.Pages.Any(e => e.PageId == id);
        }
    }
}
