using System;
using System.Collections.Generic;

namespace Tomasos.Models
{
    public partial class DishIngredient
    {
        //public int DishId { get; set; }
        //public int IngredientId { get; set; }

        public int Id { get; set; }
        public virtual Dish Dish { get; set; }
        public virtual Ingredient Ingredient { get; set; }
    }
}
