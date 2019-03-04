using System;
using System.Collections.Generic;

namespace Tomasos.Models
{
    public partial class OrderDish
    {
        public int Id { get; set; }
        public int Amount { get; set; }

        public virtual Order Order { get; set; }
        public virtual Dish Dish { get; set; }
    }
}
