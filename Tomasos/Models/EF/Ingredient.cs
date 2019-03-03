using System;
using System.Collections.Generic;

namespace Tomasos.Models
{
    public partial class Ingredient
    {
        public Ingredient()
        {
            DishIngredients = new HashSet<DishIngredient>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<DishIngredient> DishIngredients { get; set; }
    }
}
