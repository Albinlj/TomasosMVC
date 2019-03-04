using System;
using System.Collections.Generic;

namespace Tomasos.Models
{
    public partial class DishType
    {
        public DishType()
        {
            Dishes = new HashSet<Dish>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Dish> Dishes { get; set; }
    }
}
