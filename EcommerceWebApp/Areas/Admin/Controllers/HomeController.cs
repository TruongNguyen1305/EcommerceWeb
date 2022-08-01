using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var accountId = HttpContext.Session.GetString("AccountId");
            if (!string.IsNullOrEmpty(accountId))
            {
                return View();
            }
            return RedirectToAction("Login","Accounts");
        }
    }
}
