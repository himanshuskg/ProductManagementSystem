using Microsoft.Extensions.DependencyInjection;
using ProductManagementSystem.BAL.Interfaces;
using ProductManagementSystem.BAL.Services;

namespace ProductManagementSystem.BAL
{
    public static class BALServiceRegisteration
    {
        public static IServiceCollection AddBALServices(this IServiceCollection services) 
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            return services;
        }
    }
}
