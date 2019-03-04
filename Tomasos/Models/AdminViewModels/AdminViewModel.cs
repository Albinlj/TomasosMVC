using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tomasos.Models.OrderViewModels;

namespace Tomasos.Models.AdminViewModels
{
    public class AdminViewModel
    {
        public UserEditViewModel UserEditViewModel { get; set; }
        public AdminDishesViewModel AdminDishesViewModel { get; set; }
        public OrdersViewModel OrdersViewModel { get; set; }
        public IngredientsEditViewModel IngredientsEditViewModel { get; set; }

        public AdminViewModel()
        {
            UserEditViewModel = new UserEditViewModel();
            AdminDishesViewModel = new AdminDishesViewModel();
            OrdersViewModel = new OrdersViewModel();
            IngredientsEditViewModel = new IngredientsEditViewModel();
        }
    }
}
