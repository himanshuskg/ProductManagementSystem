using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductManagementSystem.DAL.Data;
using ProductManagementSystem.DAL.Repositories.Implementations;
using ProductManagementSystem.DAL.Repositories.Interfaces;

namespace ProductManagementSystem.DAL
{
    public static class DALServiceRegistration
    {
        public static IServiceCollection AddDALServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>options.UseSqlServer(configuration.GetConnectionString("DefaultConnection") ,b => b.MigrationsAssembly("ProductManagementSystem.DAL")));
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();

            return services;
        }
    }
}
