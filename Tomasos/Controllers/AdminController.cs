using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tomasos.Data;
using Tomasos.Models;
using Tomasos.Models.AdminViewModels;
using Tomasos.Models.DishViewModels;
using Tomasos.Models.OrderViewModels;

namespace Tomasos.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        public UserManager<AppUser> UserManager { get; }
        public IdentityContext IdentityContext { get; set; }


        public AdminController(
            UserManager<AppUser> userManager,
            IdentityContext identityContext)
        {
            UserManager = userManager;
            IdentityContext = identityContext;
        }

        //public IActionResult Index()
        public async Task<IActionResult> Index()
        {
            AdminViewModel viewModel = new AdminViewModel();

            foreach (var user in IdentityContext.Users.ToList())
            {
                viewModel.UserEditViewModel.Users.Add(
                    new UserEditViewModel.UserPremiumViewModel()
                    {
                        Name = user.FirstName + " " + user.LastName,
                        BonusPoints = user.BonusPoints,
                        IsPremium = await UserManager.IsInRoleAsync(user, Roles.Premium.ToString()),
                        UserId = user.Id
                    });
            }

            foreach (var dish in IdentityContext.Dishes)
            {
                viewModel.AdminDishesViewModel.EditDishViewModels.Add(new DishViewModel()
                {
                    Dish = dish,
                    //availableIngredients = dish.Ingredients,
                    DishTypes = IdentityContext.DishTypes.ToList()
                });
            }

            viewModel.OrdersViewModel.Orders = IdentityContext.Orders.Include(o => o.OrderDishes).ToList();
            viewModel.IngredientsEditViewModel.Ingredients = IdentityContext.Ingredients.ToList();

            return View(viewModel);
        }

        public async Task<IActionResult> ChangePremium(string id)
        {
            AppUser user = await UserManager.FindByIdAsync(id);

            bool isPremium = await UserManager.IsInRoleAsync(user, Roles.Premium.ToString());
            if (user != null)
            {
                if (isPremium)
                    await UserManager.RemoveFromRoleAsync(user, Roles.Premium.ToString());
                else
                    await UserManager.AddToRoleAsync(user, Roles.Premium.ToString());
            }

            return Content(!isPremium ? "True" : "False");
            //return View(user);
        }

        [HttpGet]
        public IActionResult Orders()
        {
            var model = new OrdersViewModel();
            model.Orders = IdentityContext.Orders.ToList();
            return View(model);
        }
    }
}