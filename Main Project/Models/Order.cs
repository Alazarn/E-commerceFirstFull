using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerceFirstFull.Models
{
    public class Order
    {
        public Guid Id;
        public List<OrderItem> Items { get; }
        public int TotalCount => Items.Sum(i => i.Count);

        public decimal TotalPrice => Items.Sum(i => i.Count * i.Price);

        public Order(Guid id, IEnumerable<OrderItem> orderItems)
        {
            Id = id;
            Items = new List<OrderItem>(orderItems);
        }

        public void AddOrUpdateItem(Product product, int count)
        {
            int index = Items.FindIndex(i => i.ProductId == product.Id);
            if (index == -1)
                Items.Add(new OrderItem(product.Id, count, product.Price));
            else
                Items[index].Count += count;
        }


        public void RemoveItem(Guid productId)
        {
            int index = Items.FindIndex(i => i.ProductId == productId);

            Items.RemoveAt(index);
        }

        public void RemoveAllItems()
        {     
            Items.Clear();
        }
    }
}
