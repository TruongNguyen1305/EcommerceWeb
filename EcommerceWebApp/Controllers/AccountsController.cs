using AspNetCoreHero.ToastNotification.Abstractions;
using EcommerceWebApp.Extension;
using EcommerceWebApp.Helper;
using EcommerceWebApp.Models;
using EcommerceWebApp.ModelView;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EcommerceWebApp.Controllers
{
    [Authorize]
    public class AccountsController : Controller
    {
        private readonly EcommerceShopContext _context;
        public AccountsController(EcommerceShopContext context)
        {
            _context = context;
        }

        public bool ValidatePhone(string phone)
        {
            try
            {
                var customer = _context.Customers.AsNoTracking().SingleOrDefault(x=>x.Phone.ToLower()==phone);
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

        public IActionResult Dashboard()
        {
            var AccountId = HttpContext.Session.GetString("CustomerId");
            if (AccountId != null)
            {
                var customer = _context.Customers.FirstOrDefault(x => x.CustomerId == Convert.ToInt32(AccountId));
                if (customer != null)
                {
                    if (!string.IsNullOrEmpty(HttpContext.Session.GetString("Message")))
                    {
                        ViewBag.Message = HttpContext.Session.GetString("Message");
                        HttpContext.Session.Remove("Message");
                    }
                    return View(customer);
                }
            }
            return RedirectToAction("Login");
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel customer)
        {
            try
            {
                if (!ValidateEmail(customer.Email))
                {
                    ModelState.AddModelError("Email", $"Email {customer.Email} is used");
                }
                if (!ValidatePhone(customer.Phone))
                {
                    ModelState.AddModelError("Phone", $"Phone {customer.Phone} is used");
                }
                if (ModelState.IsValid)
                {
                    string Salt = Utilities.GetRandomKey();
                    Customer cus = new Customer()
                    {
                        FullName = customer.FullName,
                        Phone = customer.Phone.Trim().ToLower(),
                        Email = customer.Email.Trim().ToLower(),
                        Password = (customer.Password + Salt).ToMD5(),
                        Active = true,
                        Salt = Salt,
                        CreateDate = DateTime.Now
                    };
                    try
                    {
                        _context.Add(cus);
                        await _context.SaveChangesAsync();
                        HttpContext.Session.SetString("CustomerId", cus.CustomerId.ToString());
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, cus.FullName),
                            new Claim("CustomerId", cus.CustomerId.ToString())
                        };
                        ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Login");
                        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                        await HttpContext.SignInAsync(claimsPrincipal);
                        return RedirectToAction("Dashboard", "Accounts");
                    }
                    catch (Exception e)
                    {
                        return View(customer);
                    }
                }
                else
                {
                    return View(customer);
                }
            }
            catch(Exception e)
            {
                return RedirectToAction("Register", "Accounts");
            }
        }
        [AllowAnonymous]
        public IActionResult Login()
        {
            var AccountId = HttpContext.Session.GetString("CustomerId");
            if(AccountId != null)
            {
                return RedirectToAction("Dashboard", "Accounts");
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel customer)
        {
            try
            {
                bool isEmail = Utilities.IsValidEmail(customer.Email);
                if (!isEmail)
                {
                    ModelState.AddModelError("Email", "Your email isn't correct !!!");
                }
                if (ModelState.IsValid)
                {
                    var cus = _context.Customers.AsNoTracking().SingleOrDefault(x=>x.Email.Trim()==customer.Email);
                    if (cus == null)
                    {
                        ViewBag.Error = "Not registered for this email yet";
                        return View(customer);
                    }
                    var pass = (customer.Password + cus.Salt.Trim()).ToMD5();
                    if (cus.Password != pass)
                    {
                        ViewBag.Error = "Your password is not correct";
                        return View(customer);
                    }
                    if (cus.Active == null) return RedirectToAction("Announce","Accounts");
                    HttpContext.Session.SetString("CustomerId", cus.CustomerId.ToString());
                    var AccountId = HttpContext.Session.GetString("CustomerId");
                    var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, cus.FullName),
                            new Claim("CustomerId", cus.CustomerId.ToString())
                        };
                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Login");
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                    await HttpContext.SignInAsync(claimsPrincipal);
                    return RedirectToAction("Dashboard", "Accounts");
                }
                else
                {
                    return View(customer);
                }
            }
            catch (Exception e)
            {
                return View(customer);
            }
        }
        [AllowAnonymous]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult ChangePassword(ChangePasswordViewModel model)
        {
            try
            {
                var AccountId = HttpContext.Session.GetString("CustomerId");
                var customer = _context.Customers.FirstOrDefault(x => x.CustomerId == Convert.ToInt32(AccountId));
                var oldPass = (model.PasswordNow + customer.Salt.Trim()).ToMD5();
                if(oldPass != customer.Password)
                {
                    ModelState.AddModelError("Password","Your current password isn't correct !");
                }
                if (ModelState.IsValid)
                {
                    customer.Password = (model.Password + customer.Salt.Trim()).ToMD5();
                    _context.Update(customer);
                    _context.SaveChanges();
                    HttpContext.Session.SetString("Message", "Change password successfully !");
                }
                return RedirectToAction("Dashboard", "Accounts");
            }
            catch(Exception e)
            {
                return RedirectToAction("Dashboard", "Accounts");
            }
        }
    }
}

