using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tomasos.Data;
using Tomasos.Models;
using Tomasos.Models.MenuViewModels;

namespace Tomasos.Controllers
{
    public class MenuController : Controller

    {
        public IdentityContext IdentityContext { get; set; }

        public MenuController(IdentityContext identityContext)
        {
            IdentityContext = identityContext;
        }
        public IActionResult Index()
        {
            var viewModel = new ListViewModel()
            {
                DishType = IdentityContext.DishTypes.Include(dt => dt.Dishes).ThenInclude(d => d.DishIngredients).ThenInclude(di => di.Ingredient)
            };

            return View(viewModel);
        }
    }
}