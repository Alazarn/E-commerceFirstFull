using System;
using System.Collections.Generic;
using System.Linq;
using E_commerceFirstFull.Models;
using E_commerceFirstFull.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace E_commerceFirstFull.Infrastructure
{
    public class ProductRepository : IProductRepository<Product>
    {
        private  StoreDbContext context { get; set; }

        public ProductRepository(StoreDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Product> Products => context.Products;

        public IEnumerable<Product> GetByTitle(string searchQuery)
        {
            if (string.IsNullOrEmpty(searchQuery))
                return Products;            
            else
                return Products.Where(x => x.Title.ToLower().Contains(searchQuery.ToLower()));            
        }

        public Product GetById(Guid id)
        {
            return Products.Single(p => p.Id == id);
        }

        public IEnumerable<Product> GetAllById(IEnumerable<Guid> ids)
        {
            return Products.Join(ids, p => p.Id, i => i, (p, i) => p);
        }

        public void Create(Product product)
        {            
            context.Products.Add(product);
            context.SaveChangesAsync();
        }

        public IEnumerable<Product> Delete(Product product)
        {
            context.Products.Remove(product);
            context.SaveChanges();
            return context.Products;

        }        

        public void Update(Product entity)
        {
            throw new NotImplementedException(); //in todo list
        }
    }
}
