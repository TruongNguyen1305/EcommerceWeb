using EcommerceWebApp.Models;
using EcommerceWebApp.ModelView;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly EcommerceShopContext _context;

        public CartController(EcommerceShopContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var AccountId = HttpContext.Session.GetString("CustomerId");
            if (string.IsNullOrEmpty(AccountId))
            {
                return RedirectToAction("Login", "Accounts");
            }
            var lsOrder = _context.OrderDetails.AsNoTracking()
                                        .Include(x => x.Order).Include(x=>x.Product).Include(x=>x.Order.TransactStatus)
                                        .Where(x => x.Order.CustomerId == Convert.ToInt32(AccountId))
                                        .OrderByDescending(x=>x.Order.OrderDate).ToList();
            return View(lsOrder);
        }

        [HttpGet]
        public IActionResult GetNumberCart()
        {
            var AccountId = HttpContext.Session.GetString("CustomerId");
            if (string.IsNullOrEmpty(AccountId))
            {
                return Json(new {numberCart = 0});
            }
            var lsOrder = _context.Orders.AsNoTracking()
                                        .Include(x => x.Customer)
                                        .Where(x => x.CustomerId == Convert.ToInt32(AccountId))
                                        .ToList();
            return Json(new { numberCart = lsOrder.Count });
        }

        [HttpPost]
        public IActionResult AddToCart(int ProductId, int Quantity)
        {
            var AccountId = HttpContext.Session.GetString("CustomerId");
            if (string.IsNullOrEmpty(AccountId))
            {
                return Json(new { status = "fail", redirectUrl = "/Accounts/Login" }); 
            }
            var product = _context.Products.AsNoTracking().FirstOrDefault(x => x.ProductId == ProductId);
            var transactStatus = _context.TransactStatuses.AsNoTracking().FirstOrDefault(x => x.TransactStatusId == 20);
            Order order = new Order
            {
                CustomerId = Convert.ToInt32(AccountId),
                OrderDate = DateTime.Now,
                TransactStatusId = transactStatus.TransactStatusId,
                TransactStatus = transactStatus,
                Paid = false,
                Deleted = false
            };
            OrderDetail orderDetail = new OrderDetail
            {
                OrderId = order.OrderId,
                ProductId = ProductId,
                Discount = product.Discount,
                Quantity = Quantity,
                Total = product.Price*Quantity,
                Order = order,
                Product = product
            };
            if(product.Discount != null)
            {
                orderDetail.Total -= product.Price * Quantity * product.Discount/100;
            }
            product.UnitslnStock -= Quantity;
            _context.Update(product);
            _context.Update(transactStatus);
            _context.Add(order);
            _context.Add(orderDetail);
            _context.SaveChanges();
            return Json(new { status = "success" , redirectUrl = "/Product" });
        }

        [HttpPost]
        public IActionResult RemoveItem(int OrderDetailId)
        {
            var AccountId = HttpContext.Session.GetString("CustomerId");
            var oderDetail = _context.OrderDetails.AsNoTracking().Include(x=>x.Order).FirstOrDefault(x => x.OrderDetailId == OrderDetailId); 
            if (oderDetail != null)
            {
                var order = oderDetail.Order;
                var product = _context.Products.AsNoTracking().FirstOrDefault(x=>x.ProductId == oderDetail.ProductId);
                product.UnitslnStock += oderDetail.Quantity;
                _context.Remove(order);
                _context.Update(product);
                _context.SaveChanges();
            }
            var lsOrder = _context.OrderDetails.AsNoTracking()
                                        .Include(x => x.Order).Include(x => x.Product).Include(x=>x.Order.TransactStatus)
                                        .Where(x => x.Order.CustomerId == Convert.ToInt32(AccountId))
                                        .OrderByDescending(x => x.Order.OrderDate).ToList();
            return PartialView("CartPartialView", lsOrder);
        }
    }
}
