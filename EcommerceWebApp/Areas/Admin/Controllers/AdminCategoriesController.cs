using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EcommerceWebApp.Models;
using PagedList.Core;
using AspNetCoreHero.ToastNotification.Abstractions;
using EcommerceWebApp.Helper;
using System.IO;

namespace EcommerceWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminCategoriesController : Controller
    {
        private readonly EcommerceShopContext _context;
        public INotyfService _inotyfService { get; }
        public AdminCategoriesController(EcommerceShopContext context, INotyfService inotyfService)
        {
            _context = context;
            _inotyfService = inotyfService;
        }

        // GET: Admin/AdminCategories
        public async Task<IActionResult> Index(int? page)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Accounts");
            }
            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 12;
            var CatsList = _context.Categories.AsNoTracking().OrderByDescending(x => x.CatId);
            int maxNumPage = (int)Math.Ceiling((double)CatsList.Count() / pageSize);
            if (maxNumPage < pageNumber)
            {
                pageNumber--;
            }
            if (pageNumber == 0)
            {
                pageNumber = 1;
            }
            PagedList<Category> models = new PagedList<Category>(CatsList, pageNumber, pageSize);
            ViewBag.CurrentPage = pageNumber;
            return View(models);
        }

        // GET: Admin/AdminCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.CatId == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: Admin/AdminCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CatId,CatName,Description,Password,ParentId,Levels,Ordering,Published,Thumb,Title,Alias,MetaDesc,MetaKey,Cover,SchemaMarkup")] Category category, Microsoft.AspNetCore.Http.IFormFile fThumb)
        {
            if (ModelState.IsValid)
            {
                if (fThumb != null)
                {
                    string extension = Path.GetExtension(fThumb.FileName);
                    string image = Utilities.SEOUrl(category.CatName) + extension;
                    category.Thumb = await Utilities.UploadFile(fThumb, @"categories", image.ToLower());
                }
                if (string.IsNullOrEmpty(category.Thumb))
                {
                    category.Thumb = "default.jpg";
                }
                category.Alias = Utilities.SEOUrl(category.CatName);
                _context.Add(category);
                await _context.SaveChangesAsync();
                _inotyfService.Success("Success");
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Admin/AdminCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Admin/AdminCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CatId,CatName,Description,Password,ParentId,Levels,Ordering,Published,Thumb,Title,Alias,MetaDesc,MetaKey,Cover,SchemaMarkup")] Category category, Microsoft.AspNetCore.Http.IFormFile fThumb)
        {
            if (id != category.CatId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (fThumb != null)
                    {
                        string extension = Path.GetExtension(fThumb.FileName);
                        string image = Utilities.SEOUrl(category.CatName) + extension;
                        category.Thumb = await Utilities.UploadFile(fThumb, @"categories", image.ToLower());
                    }
                    if (string.IsNullOrEmpty(category.Thumb))
                    {
                        category.Thumb = "default.jpg";
                    }
                    category.Alias = Utilities.SEOUrl(category.CatName);
                    _context.Update(category);
                    await _context.SaveChangesAsync();
                    _inotyfService.Success("Success");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.CatId))
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
            return View(category);
        }

        // GET: Admin/AdminCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.CatId == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Admin/AdminCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            _inotyfService.Success("Success");
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.CatId == id);
        }
    }
}
