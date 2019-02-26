using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Tomasos.Helpers;
using Tomasos.Models;

namespace Tomasos.Controllers
{
    [Route("cart")]
    public class CartController : Controller
    {
        public TomasosContext TomasosContext { get; set; }

        public CartController(TomasosContext tomasosContext)
        {
            TomasosContext = tomasosContext;
        }

        [Route("index")]
        public IActionResult Index()
        {
            Cart cart = SessionHelper.GetObjectFromJson<Cart>(HttpContext.Session, "cart");
            return View(cart);
        }

        [Route("add/{id}")]
        public IActionResult Add(int id)
        {
            //ProductModel productModel = new ProductModel();
            if (SessionHelper.GetObjectFromJson<Cart>(HttpContext.Session, "cart") == null)
            {
                Cart cart = new Cart();

                cart.Add(new Item()
                {
                    Matratt = TomasosContext.Matratt.Find(id),
                    Quantity = 1
                });

                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                Cart cart = SessionHelper.GetObjectFromJson<Cart>(HttpContext.Session, "cart");
                int index = isExist(id);
                if (index != -1)
                {
                    cart.Items[index].Quantity++;
                }
                else
                {
                    cart.Items.Add(new Item
                    {
                        Matratt = TomasosContext.Matratt.Find(id),
                        Quantity = 1
                    });
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("Index");
        }

        [Route("remove/{id}")]
        public IActionResult Remove(int id)
        {
            List<Produkt> cart = SessionHelper.GetObjectFromJson<List<Produkt>>(HttpContext.Session, "cart");
            int index = isExist(id);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }

        private int isExist(int id)
        {
            Cart cart = SessionHelper.GetObjectFromJson<Cart>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Items.Count; i++)
            {
                if (cart.Items[i].Matratt.MatrattId.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }

    }
}