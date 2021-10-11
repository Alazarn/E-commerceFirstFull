using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerceFirstFull.Models
{
    public class OrderItem
    {
        public Guid ProductId { get; }

        public int Count { get; set; }

        public decimal Price { get; set; }

        public OrderItem(Guid productId, int count, decimal price)
        {
            ProductId = productId;
            Count = count;
            Price = price;
        }

    }
}
