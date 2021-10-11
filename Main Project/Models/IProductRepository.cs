using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerceFirstFull.Models
{
    public interface IProductRepository<T>
    {
        IEnumerable<T> Products { get; }
        IEnumerable<T> GetByTitle(string query);
        Product GetById(Guid id);
        public IEnumerable<Product> GetAllById(IEnumerable<Guid> ids);
        void Create(T entity);
        void Update(T entity);
        IEnumerable<T> Delete(T entity);

    }
}
