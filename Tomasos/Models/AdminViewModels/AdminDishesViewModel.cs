using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tomasos.Models.DishViewModels;

namespace Tomasos.Models.AdminViewModels
{
    public class AdminDishesViewModel
    {
        public List<EditDishViewModel> EditDishViewModels { get; set; } = new List<EditDishViewModel>();
    }
}
