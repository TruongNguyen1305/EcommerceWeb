using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EcommerceWebApp.Models;
using AspNetCoreHero.ToastNotification.Abstractions;
using PagedList.Core;

namespace EcommerceWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminOrdersController : Controller
    {
        private readonly EcommerceShopContext _context;
        public INotyfService _inotyfService { get; }
        public AdminOrdersController(EcommerceShopContext context, INotyfService inotyfService)
        {
            _context = context;
            _inotyfService = inotyfService;
        }

        // GET: Admin/AdminOrders
        public async Task<IActionResult> Index(int? page, int transactStatusID = 0)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Accounts");
            }
            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 20;
            var ordersList = _context.Orders.AsNoTracking().Include(x => x.Customer).Include(x => x.TransactStatus).OrderByDescending(x => x.OrderDate);
            if (transactStatusID != 0)
            {
                ordersList = (IOrderedQueryable<Order>)ordersList.Where(x => x.TransactStatusId == transactStatusID);
            }
            int maxNumPage = (int)Math.Ceiling((double)ordersList.Count() / pageSize);
            if (maxNumPage < pageNumber)
            {
                pageNumber--;
            }
            if (pageNumber == 0)
            {
                pageNumber = 1;
            }
            PagedList<Order> models = new PagedList<Order>(ordersList, pageNumber, pageSize);
            ViewBag.CurrentPage = pageNumber;
            ViewBag.TransactStatusID = transactStatusID;
            ViewBag.TransactStatus = new SelectList(_context.TransactStatuses, "TransactStatusId", "Status", transactStatusID);
            return View(models);
        }

        // GET: Admin/AdminOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.TransactStatus)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Admin/AdminOrders/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId");
            ViewData["TransactStatusId"] = new SelectList(_context.TransactStatuses, "TransactStatusId", "TransactStatusId");
            return View();
        }

        // POST: Admin/AdminOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,CustomerId,OrderDate,ShipDate,TransactStatusId,Deleted,Paid,PaymentDate,PaymentId,Note")] Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                _inotyfService.Success("Create success");
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId", order.CustomerId);
            ViewData["TransactStatusId"] = new SelectList(_context.TransactStatuses, "TransactStatusId", "TransactStatusId", order.TransactStatusId);
            return View(order);
        }

        // GET: Admin/AdminOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId", order.CustomerId);
            ViewData["TransactStatus"] = new SelectList(_context.TransactStatuses, "TransactStatusId", "Status", order.TransactStatusId);
            return View(order);
        }

        // POST: Admin/AdminOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,CustomerId,OrderDate,ShipDate,TransactStatusId,Deleted,Paid,PaymentDate,PaymentId,Note")] Order order)
        {
            if (id != order.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if(order.Paid)
                    {
                        order.PaymentDate =DateTime.Now;
                        order.TransactStatusId = 22;
                    }
                    else
                    {
                        order.PaymentDate = null;
                    }
                    if (order.TransactStatusId == 23)
                    {
                        order.Deleted = true;
                        order.PaymentDate = null;
                        order.ShipDate = null;
                    }
                    else
                    {
                        order.Deleted = false;
                    }
                    if (order.TransactStatusId == 21)
                    {
                        order.ShipDate = DateTime.Now;
                    }
                    order.TransactStatus = _context.TransactStatuses.AsNoTracking().FirstOrDefault(x => x.TransactStatusId == order.TransactStatusId);
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                    _inotyfService.Success("Edit success");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.OrderId))
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
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId", order.CustomerId);
            ViewData["TransactStatusId"] = new SelectList(_context.TransactStatuses, "TransactStatusId", "TransactStatusId", order.TransactStatusId);
            return View(order);
        }

        // GET: Admin/AdminOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.TransactStatus)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Admin/AdminOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order.TransactStatusId == 23)
            {
                var orderDetail = _context.OrderDetails.AsNoTracking().Include(x => x.Product).FirstOrDefault(x => x.OrderId == id);
                var product = orderDetail.Product;
                product.UnitslnStock += orderDetail.Quantity;
                _context.Update(product);
            }
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            _inotyfService.Success("Delete success");
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Filter(int TransactStatusId = 0)
        {
            var url = $"/Admin/AdminOrders?transactStatusID={TransactStatusId}";
            if (TransactStatusId == 0)
            {
                url = $"/Admin/AdminOrders";
            }
            return Json(new { status = "success", redirectUrl = url });
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.OrderId == id);
        }
    }
}
