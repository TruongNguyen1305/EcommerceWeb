using EcommerceWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EcommerceShopContext _context;
        public HomeController(ILogger<HomeController> logger, EcommerceShopContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.LatestProducts = _context.Products.AsNoTracking().Include(x => x.Cat).OrderByDescending(x=>x.DateCreated).Take(7).ToList();
            ViewBag.BestSellers = _context.Products.AsNoTracking().Include(x => x.Cat).Where(x => x.BestSellers).OrderByDescending(x => x.UnitslnStock).Take(7).ToList();
            return View();
        }

        public IActionResult ShopPage()
        {
            return View();
        }

        public IActionResult SingleProduct()
        {
            return View();
        }

        public IActionResult Cart()
        {
            return View();
        }

        public IActionResult CheckOut()
        {
            return View();
        }

        public IActionResult Category()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
