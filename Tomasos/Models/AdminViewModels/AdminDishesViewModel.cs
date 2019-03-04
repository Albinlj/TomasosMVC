using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tomasos.Models.DishViewModels;

namespace Tomasos.Models.AdminViewModels
{
    public class AdminDishesViewModel
    {
        public List<DishViewModel> EditDishViewModels { get; set; } = new List<DishViewModel>();
    }
}
