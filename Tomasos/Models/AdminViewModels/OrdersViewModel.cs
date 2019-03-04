using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tomasos.Models.OrderViewModels
{
    public class OrdersViewModel
    {
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
