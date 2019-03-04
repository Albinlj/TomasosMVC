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
        public UserManager<AppUser> _UserManager { get; set; }
        public HomeController(UserManager<AppUser> userManager)
        {
            _UserManager = userManager;
        }


        public IActionResult Index()
        {

            CartModelView cartModelView = SessionHelper.GetObjectFromJson<CartModelView>(HttpContext.Session, "cartModelView");
            if (cartModelView == null)
            {
            CartModelView emptyCart = new CartModelView();
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cartModelView", emptyCart);
            }
            return View();
        }

        [Authorize]
        public IActionResult Privacy()
        {
            AppUser user = _UserManager.GetUserAsync
                (HttpContext.User).Result;

            ViewBag.Message = $"Welcome {user.Email}!";
            if (_UserManager.IsInRoleAsync(user, "NormalUser").Result)
            {
                ViewBag.RoleMessage = "You are a NormalUser.";
            }
            return View();
        }

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
