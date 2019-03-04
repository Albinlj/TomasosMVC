using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required]
        [RegularExpression("^[a-zèA-Z ]{2,}$", ErrorMessage = "Name can only contain letters A-Z")]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(5, 2)")]
        public decimal Price { get; set; }
        public DishType Type { get; set; }
        public List<Ingredient> Ingredients { get; set; }

        public virtual ICollection<OrderDish> Orders { get; set; }
        public virtual ICollection<DishIngredient> DishIngredients { get; set; }
    }
}
