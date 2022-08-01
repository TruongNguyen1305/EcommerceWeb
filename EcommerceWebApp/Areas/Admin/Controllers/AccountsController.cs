using AspNetCoreHero.ToastNotification.Abstractions;
using EcommerceWebApp.Extension;
using EcommerceWebApp.Helper;
using EcommerceWebApp.Models;
using EcommerceWebApp.ModelView;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EcommerceWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountsController : Controller
    {
        private readonly EcommerceShopContext _context;
        public INotyfService _inotyfService { get; }
        public AccountsController(EcommerceShopContext context, INotyfService inotyfService)
        {
            _context = context;
            _inotyfService = inotyfService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Accounts");
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            try
            {
                bool isEmail = Utilities.IsValidEmail(model.Email);
                if (!isEmail)
                {
                    ModelState.AddModelError("Email", "Your email isn't correct !!!");
                }
                if (ModelState.IsValid)
                {
                    var acc = _context.Accounts.AsNoTracking().Include(x=>x.Role).SingleOrDefault(x => x.Email.Trim() == model.Email);
                    if (acc == null)
                    {
                        ViewBag.Error = "Not registered for this email yet";
                        return View(model);
                    }
                    var pass = (model.Password + acc.Salt.Trim()).ToMD5();
                    if (acc.Password != pass)
                    {
                        ViewBag.Error = "Your password is not correct";
                        return View(model);
                    }
                    acc.LastLogin = DateTime.Now;
                    _context.Update(acc);
                    _context.SaveChanges();
                    HttpContext.Session.SetString("AccountId", acc.AccountId.ToString());
                    var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, acc.FullName),
                            new Claim("AccountId", acc.AccountId.ToString()),
                            new Claim("Role", acc.Role.RoleName)
                        };
                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Login");
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                    await HttpContext.SignInAsync(claimsPrincipal);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View(model);
                }
            }
            catch (Exception e)
            {
                return View(model);
            }
        }
    }
}

