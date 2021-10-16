using E_commerceFirstFull.Infrastructure;
using E_commerceFirstFull.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;

namespace E_commerceFirstFull.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<StoreDbContext>(opts => {
                opts.UseSqlServer(configuration["ConnectionStrings:GameStoreConnection"]);
            });
        }

        public static void ConfigureIISIntegration(this IServiceCollection services) //in todo
        {
            services.Configure<IISOptions>(options =>
            {

            });
        }

        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole>(o =>
            {
                o.Password.RequireDigit = false;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 4;
                o.User.RequireUniqueEmail = false;
            })
              .AddEntityFrameworkStores<StoreDbContext>();        
        }
    }
}
