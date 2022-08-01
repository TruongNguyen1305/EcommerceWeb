using EcommerceWebApp.Models;
using EcommerceWebApp.ModelView;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebApp.Controllers
{
    public class CheckOutController : Controller
    {
        private readonly EcommerceShopContext _context;
        public CheckOutController(EcommerceShopContext context)
        {
            _context = context;
        }
        public IActionResult Index(int? OrderId)
        {
            try
            {
                var orderDetail = _context.OrderDetails.AsNoTracking()
                                                    .Include(x => x.Order)
                                                    .Include(x => x.Product)
                                                    .FirstOrDefault(x => x.OrderId == OrderId);
                return View(orderDetail);
            }
            catch(Exception e)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult BuySuccess(BuySuccessViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var orderDetail = _context.OrderDetails.AsNoTracking()
                        .Include(x => x.Order)
                        .Include(x => x.Product)
                        .Include(x => x.Order.Customer)
                        .FirstOrDefault(x => x.Order.OrderId == model.OrderId);
                    //Update customer
                    var customer = orderDetail.Order.Customer;
                    customer.Address = model.Address;
                    //update order
                    var transactStatus = _context.TransactStatuses.AsNoTracking().FirstOrDefault(x => x.TransactStatusId == 19);
                    var order = orderDetail.Order;
                    order.TransactStatusId = transactStatus.TransactStatusId;
                    order.TransactStatus = transactStatus;
                    //_context.Update(transactStatus);
                    _context.Update(customer);
                    _context.Update(order);
                    _context.Update(orderDetail);
                    _context.SaveChanges();
                    return RedirectToAction("Index", "Cart");
                }
                return RedirectToAction("Index", "CheckOut",model.OrderId);
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }
    }
}
