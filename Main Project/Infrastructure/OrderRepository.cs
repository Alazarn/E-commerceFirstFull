using E_commerceFirstFull.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerceFirstFull.Infrastructure
{
    public class OrderRepository : IOrderRepository
    {
        private readonly List<Order> Orders = new();

        public Order Create()
        {
            Guid nextId = Guid.NewGuid();
            var order = new Order(nextId, new OrderItem[0]);

            Orders.Add(order);

            return order;
        }

        public Order GetById(Guid id) => Orders.Single(o => o.Id == id);

        public void Update(Order order)
        {
        }
    }
}
