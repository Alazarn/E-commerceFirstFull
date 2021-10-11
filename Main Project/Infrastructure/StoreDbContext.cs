using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using E_commerceFirstFull.Models;
using E_commerceFirstFull.Infrastructure.Configuration;

namespace E_commerceFirstFull.Infrastructure
{
    public class StoreDbContext : IdentityDbContext<User>
    {
        public DbSet<Product> Products { get; set; }

        public StoreDbContext(DbContextOptions<StoreDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ProductConfiguration());
        }
    }
}
