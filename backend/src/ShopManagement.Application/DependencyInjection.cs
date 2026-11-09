using Microsoft.Extensions.DependencyInjection;
using ShopManagement.Application.Products;

namespace ShopManagement.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();
        return services;
    }
}
