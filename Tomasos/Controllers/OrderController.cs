using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tomasos.Data;
using Tomasos.Models;

namespace Tomasos.Controllers
{

    [Authorize(Roles = "Administrator")]
    public class OrderController : Controller
    {
        public IdentityContext IdentityContext { get; set; }

        public OrderController(IdentityContext identityContext)
        {
            IdentityContext = identityContext;
        }


        public IActionResult Delete(int id)
        {
            Order order = IdentityContext.Orders.Include(o => o.User).First(o => o.Id == id);
            Order orderClone = new Order
            {
                Id = order.Id,
                User = order.User,
                Sum = order.Sum,
            };
            List<OrderDish> orderDishes = IdentityContext.OrderDishes.Where(od => od.Order.Id == id).ToList();
            IdentityContext.OrderDishes.RemoveRange(orderDishes);
            IdentityContext.Orders.Remove(order);
            IdentityContext.SaveChanges();
            return View(orderClone);
        }

        public IActionResult Delivered(int id)
        {
            Order order = IdentityContext.Orders.Find(id);
            order.IsDelivered = true;
            IdentityContext.Update(order);
            IdentityContext.SaveChanges();
            return View(order);
        }
    }
}