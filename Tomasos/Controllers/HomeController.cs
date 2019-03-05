using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Tomasos.Helpers;
using Tomasos.Models;

namespace Tomasos.Controllers
{
    public class HomeController : Controller
    {
        public UserManager<AppUser> UserManager { get; set; }
        public HomeController(UserManager<AppUser> userManager)
        {
            UserManager = userManager;
        }


        public IActionResult Index()
        {

            CartModelView cartModelView = HttpContext.Session.GetObjectFromJson<CartModelView>("cartModelView");
            if (cartModelView == null)
            {
            CartModelView emptyCart = new CartModelView();
            HttpContext.Session.SetObjectAsJson("cartModelView", emptyCart);
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
