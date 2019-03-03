using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Tomasos.Data;
using Tomasos.Helpers;
using Tomasos.Models;

namespace Tomasos.Controllers
{
    public class CartController : Controller
    {
        public IdentityContext IdentityContext { get; set; }
        public UserManager<AppUser> UserManager { get; set; }

        public CartController(IdentityContext identityContext, UserManager<AppUser> userManager)
        {
            IdentityContext = identityContext;
            UserManager = userManager;
        }

        [Route("index")]
        public IActionResult Index()
        {
            CartModelView cartModelView = SessionHelper.GetObjectFromJson<CartModelView>(HttpContext.Session, "cartModelView");
            if (cartModelView == null)
            {
                return RedirectToAction("empty", "Cart");
            }
            //if (cartModelView.Items.Count == 0)
            //{
            //}
            return View(cartModelView);
        }

        [Route("add/{id}")]
        public IActionResult Add(int id)
        {
            //ProductModel productModel = new ProductModel();
            if (SessionHelper.GetObjectFromJson<CartModelView>(HttpContext.Session, "cartModelView") == null)
            {
                CartModelView cartModelView = new CartModelView();

                cartModelView.Add(new Item()
                {
                    Dish = IdentityContext.Dishes.Find(id),
                    Quantity = 1
                });

                SessionHelper.SetObjectAsJson(HttpContext.Session, "cartModelView", cartModelView);
            }
            else
            {
                CartModelView cartModelView = SessionHelper.GetObjectFromJson<CartModelView>(HttpContext.Session, "cartModelView");
                int index = ExistsInCart(id);
                if (index != -1)
                {
                    cartModelView.Items[index].Quantity++;
                }
                else
                {
                    cartModelView.Items.Add(new Item
                    {
                        Dish = IdentityContext.Dishes.Find(id),
                        Quantity = 1
                    });
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cartModelView", cartModelView);
            }
            return RedirectToAction("Index");
        }

        [Route("remove/{id}")]
        public IActionResult Remove(int id)
        {
            CartModelView cart = SessionHelper.GetObjectFromJson<CartModelView>(HttpContext.Session, "cartModelView");
            int index = ExistsInCart(id);
            if (index != -1)
            {
                if (cart.Items[index].Quantity > 1)
                {
                    cart.Items[index].Quantity--;
                }
                else
                {
                    cart.Items.RemoveAt(index);
                }
            }
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cartModelView", cart);
            return RedirectToAction("Index");
        }

        private int ExistsInCart(int id)
        {
            CartModelView cartModelView = HttpContext.Session.GetObjectFromJson<CartModelView>("cartModelView");
            for (int i = 0; i < cartModelView.Items.Count; i++)
            {
                if (cartModelView.Items[i].Dish.Id.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }

        public async Task<IActionResult> Order()
        {
            CartModelView cartModelView = HttpContext.Session.GetObjectFromJson<CartModelView>("cartModelView");
            if (User.Identity.Name == null)
            {
                return View("~/Views/Account/Login.cshtml");
            }
            AppUser currentUser = await UserManager.FindByNameAsync(User.Identity.Name);
            Order newOrder =
                new Order
                {
                    User = currentUser,
                    IsDelivered = false,
                    OrderDate = DateTime.Now.Date,
                    OrderDishes = new List<OrderDish>(),
                };

            await IdentityContext.Orders.AddAsync(newOrder);

            foreach (Item item in cartModelView.Items)
            {
                newOrder.OrderDishes.Add(new OrderDish()
                {
                    Order = newOrder,
                    Amount = item.Quantity,
                    Dish = IdentityContext.Dishes.Include(d => d.Type).FirstOrDefault(d => d.Id == item.Dish.Id)
                });
            }
            await IdentityContext.OrderDishes.AddRangeAsync(newOrder.OrderDishes);

            newOrder.Sum = newOrder.OrderDishes.Sum(od => od.Amount * od.Dish.Price);


            List<OrderDish> pizzaOrderDishes =
                newOrder.OrderDishes.Where(od => od.Dish.Type.Description == "Pizza").OrderByDescending(od => od.Amount).ToList();
            if (currentUser.BonusPoints >= 100
                && pizzaOrderDishes.Count > 0)
            {
                newOrder.Sum -= pizzaOrderDishes[0].Amount;
            }

            if (await UserManager.IsInRoleAsync(currentUser, Roles.Premium.ToString()))
            {
                newOrder.Sum = Math.Round(newOrder.Sum * 0.8m);
                currentUser.BonusPoints += newOrder.OrderDishes.Count * 10;
            }

            await IdentityContext.SaveChangesAsync();
            return RedirectToAction("complete", newOrder);
        }

        public IActionResult Complete(Order order)
        {
            return View(order);
        }

        [HttpGet]
        public IActionResult Empty()
        {
            return View();
        }
    }

}