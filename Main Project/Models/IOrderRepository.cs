using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerceFirstFull.Models
{
    public interface IOrderRepository
    {
        Order Create();
        Order GetById(Guid id);
        void Update(Order order);
    }
}
