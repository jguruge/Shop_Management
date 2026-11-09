using ShopManagement.Api.Features.Products.Services;

namespace ShopManagement.Api.Features.Products;

public static class ProductsModule
{
    public static IServiceCollection AddProductsFeature(this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();

        return services;
    }
}
