using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tomasos.Models
{
    public partial class Dish
    {
        public Dish()
        {
            Orders = new HashSet<OrderDish>();
            DishIngredients = new HashSet<DishIngredient>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal Price { get; set; }
        public DishType Type { get; set; }
        public List<Ingredient> Ingredients { get; set; }

        public virtual ICollection<OrderDish> Orders { get; set; }
        public virtual ICollection<DishIngredient> DishIngredients { get; set; }
    }
}
