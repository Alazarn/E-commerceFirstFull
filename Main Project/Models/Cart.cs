using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerceFirstFull.Models
{
    public class Cart
    {
        public Guid OrderId { get; set; }
        public int TotalCount { get; set; }
        public decimal TotalPrice { get; set; }

        public Cart(Guid orderId)
        {
            OrderId = orderId;
            TotalCount = 0;
            TotalPrice = 0m;
        }
    }
}
