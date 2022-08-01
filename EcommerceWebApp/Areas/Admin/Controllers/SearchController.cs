using EcommerceWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SearchController : Controller
    {
        private readonly EcommerceShopContext _context;

        public SearchController(EcommerceShopContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult FindProduct(string keyword, int page)
        {
            List<Product> productList = new List<Product>();

            if (string.IsNullOrEmpty(keyword) || keyword.Trim().Length < 1)
            {
                return PartialView("ListProductsSearchPartial", _context.Products.AsNoTracking()
                                                                                 .Include(x => x.Cat)
                                                                                 .OrderByDescending(x => x.ProductId)
                                                                                 .Take(20)
                                                                                 .ToList());
            }
            productList = _context.Products.AsNoTracking()
                                           .Include(x => x.Cat)
                                           .Where(x => x.ProductName.Contains(keyword.Trim()))
                                           .OrderByDescending(x=>x.ProductId)
                                           .Take(20)
                                           .ToList();
            if(productList != null)
            {
                return PartialView("ListProductsSearchPartial", productList);
            }
            return PartialView("ListProductsSearchPartial", null);
        }
    }
}
