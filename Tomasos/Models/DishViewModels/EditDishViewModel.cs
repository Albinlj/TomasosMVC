using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Tomasos.Models.DishViewModels
{
    public class EditDishViewModel
    {
        public Dish Dish { get; set; }

        [Display(Name = "DishIngredients")]
        public List<Ingredient> AvailableIngredients { get; set; }
        public List<int> ChosenIngredients { get; set; }

        [Display(Name = "Category")]
        public List<DishType> DishTypes { get; set; }
        public int SelectedTypeId { get; set; }

        //[Display(Name = "Ingredient Name")]
        //[RegularExpression("^[a-zèA-Z ]{2,}$", ErrorMessage = "An ingredients name can only contain letters A-Z")]
        //[StringLength(20, ErrorMessage = "The name can not be longer than 20 characters")]
        //public string NewIngredient { get; set; }
    }
}
