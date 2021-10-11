using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerceFirstFull.Models.ViewModels
{
    public class OrderModel
    {
        public Guid Id { get; set; }

        public List<OrderItemModel> Items { get; set; } = new List<OrderItemModel>(0);

        public int TotalCount { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
