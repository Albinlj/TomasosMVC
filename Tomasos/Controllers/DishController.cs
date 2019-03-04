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
            var model = new DishViewModel()
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
        public IActionResult Edit(DishViewModel model)
        {
            Dish dish = IdentityContext.Dishes.Find(model.Dish.Id);
            dish.Name = model.Dish.Name;
            dish.Description = model.Dish.Description;
            dish.Type = IdentityContext.DishTypes.Find(model.SelectedTypeId);
            dish.Ingredients = IdentityContext.Ingredients.Where(i => model.ChosenIngredients.Contains(i.Id)).ToList();
            IdentityContext.DishIngredients.RemoveRange(IdentityContext.DishIngredients.Include(di => di.Dish)
                .Where(di => di.Dish.Id == model.Dish.Id).ToList());
            dish.DishIngredients = dish.Ingredients.Select(i => new DishIngredient()
            {
                Ingredient = i,
                Dish = dish,
            }).ToList();
            IdentityContext.Dishes.Update(dish);
            IdentityContext.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }


        public IActionResult Create()
        {
            DishViewModel model = new DishViewModel();
            model.AvailableIngredients = IdentityContext.Ingredients.ToList();
            model.DishTypes = IdentityContext.DishTypes.ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(DishViewModel model)
        {
            Dish dish = model.Dish;
            dish.Ingredients = IdentityContext.Ingredients.Where(i => model.ChosenIngredients.Contains(i.Id)).ToList();
            dish.DishIngredients = dish.Ingredients.Select(i => new DishIngredient()
            {
                Ingredient = i,
                Dish = dish,
            }).ToList();
            dish.Type = IdentityContext.DishTypes.FirstOrDefault(dt => dt.Id == model.SelectedTypeId);
            IdentityContext.Dishes.Add(dish);
            IdentityContext.DishIngredients.AddRange(dish.DishIngredients);
            IdentityContext.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }
    }
}