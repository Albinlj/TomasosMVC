using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tomasos.Models.AdminViewModels
{
    public class AdminViewModel
    {
        public UserEditViewModel UserEditViewModel { get; set; }
        public AdminDishesViewModel AdminDishesViewModel { get; set; }

        public AdminViewModel()
        {
            UserEditViewModel = new UserEditViewModel();
            AdminDishesViewModel = new AdminDishesViewModel();
        }
    }
}
