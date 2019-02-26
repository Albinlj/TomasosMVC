using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tomasos.Models;
using Tomasos.Models.MenuViewModels;

namespace Tomasos.Controllers
{
    public class MenuController : Controller

    {
        public TomasosContext TomasosContext { get; set; }

        public MenuController(TomasosContext tomasosContext)
        {
            TomasosContext = tomasosContext;
        }
        public IActionResult Index()
        {
            var viewModel = new ListViewModel()
            {
                MatrattTyp = TomasosContext.MatrattTyp.Include(mt => mt.Matratt).ThenInclude(m => m.MatrattProdukt).ThenInclude(mp => mp.Produkt)
            };

            return View(viewModel);
        }
    }
}