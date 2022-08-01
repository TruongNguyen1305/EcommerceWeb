using EcommerceWebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly EcommerceShopContext _context;

        public ProductController(EcommerceShopContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int? page, int CatId = 0)
        {
            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 12;
            var productsList = _context.Products.AsNoTracking().Include(x => x.Cat).OrderByDescending(x => x.ProductId).Where(x=>x.UnitslnStock>0);
            if (CatId != 0)
            {
                productsList = (IOrderedQueryable<Product>)productsList.Where(x => x.CatId == CatId);
            }
            int maxNumPage = (int)Math.Ceiling((double)productsList.Count() / pageSize);
            if (maxNumPage < pageNumber)
            {
                pageNumber--;
            }
            if (pageNumber == 0)
            {
                pageNumber = 1;
            }
            PagedList<Product> models = new PagedList<Product>(productsList, pageNumber, pageSize);
            ViewBag.CurrentPage = pageNumber;
            ViewBag.CurrentCatId = CatId;
            ViewBag.CurrentCat = _context.Categories.AsNoTracking().Where(x => x.CatId == CatId).FirstOrDefault();
            ViewData["Category"] = new SelectList(_context.Categories, "CatId", "CatName", CatId);
            return View(models);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.Include(m=>m.Cat)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            ViewBag.relatedList = _context.Products.AsNoTracking().Include(x=>x.Cat).Where(x=>x.CatId == product.CatId).OrderByDescending(x=>x.DateCreated).Take(5).ToList();
            return View(product);
        }

        public IActionResult Filter(int CatId = 0)
        {
            var url = $"/Product?CatId={CatId}";
            if (CatId == 0)
            {
                url = $"/Product";
            }
            return Json(new { status = "success", redirectUrl = url });
        }

        [HttpPost]
        public IActionResult FindProduct(string keyword, int page)
        {
            List<Product> productList = new List<Product>();

            if (string.IsNullOrEmpty(keyword) || keyword.Trim().Length < 1)
            {
                return PartialView("ProductsSearchPartial", _context.Products.AsNoTracking()
                                                                                 .Include(x => x.Cat)
                                                                                 .OrderByDescending(x => x.ProductId)
                                                                                 .Take(20)
                                                                                 .ToList());
            }
            productList = _context.Products.AsNoTracking()
                                           .Include(x => x.Cat)
                                           .Where(x => x.ProductName.Contains(keyword.Trim()))
                                           .OrderByDescending(x => x.ProductId)
                                           .Take(20)
                                           .ToList();
            if (productList != null)
            {
                return PartialView("ProductsSearchPartial", productList);
            }
            return PartialView("ProductsSearchPartial", null);
        }
    }
}
