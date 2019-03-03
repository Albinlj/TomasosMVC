using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tomasos.Data;
using Tomasos.Models;
using Tomasos.Models.DishViewModels;

namespace Tomasos.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class DishController : Controller
    {
        private IdentityContext IdentityContext { get; set; }

        public DishController(IdentityContext identityContext)
        {
            IdentityContext = identityContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Dish dish = IdentityContext.Dishes
                .Include(d => d.Type)
                .Include(d => d.Ingredients)
                .Include(d => d.DishIngredients)
                .ThenInclude(di => di.Ingredient)
                .FirstOrDefault(d => d.Id == id);
            var model = new EditDishViewModel()
            {
                Dish = dish,
                DishTypes = IdentityContext.DishTypes.ToList(),
                AvailableIngredients = IdentityContext.Ingredients.ToList(),
                SelectedTypeId = dish.Type.Id,
                ChosenIngredients = dish.DishIngredients.Select(di => di.Ingredient.Id).ToList()


            };
            return PartialView("~/Views/Admin/_EditDishPartial.cshtml", model);
        }

        [HttpPost]
        public IActionResult Edit(EditDishViewModel model)
        {
            Dish dish = IdentityContext.Dishes.Find(model.Dish.Id);
            dish.Name = model.Dish.Name;
            dish.Description = model.Dish.Description;
            dish.Type = IdentityContext.DishTypes.Find(model.SelectedTypeId);
            //dish.Ingredients = 
            IdentityContext.Dishes.Update(dish);
            IdentityContext.SaveChanges();
            return Ok();
        }
    }
}