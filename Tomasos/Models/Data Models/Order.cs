using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tomasos.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDishes = new HashSet<OrderDish>();
        }

        public int Id { get; set; }
        public AppUser User { get; set; }
        public DateTime OrderDate { get; set; }

        [Column(TypeName = "decimal(5, 2)")]
        public decimal Sum { get; set; }
        public bool IsDelivered { get; set; }

        public virtual ICollection<OrderDish> OrderDishes { get; set; }
    }
}
