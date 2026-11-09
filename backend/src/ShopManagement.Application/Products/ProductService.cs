using ShopManagement.Application.Common.Exceptions;
using ShopManagement.Application.Common.Interfaces;
using ShopManagement.Application.Products.Dtos;
using ShopManagement.Domain.Entities;

namespace ShopManagement.Application.Products;

public class ProductService(IRepository<Product> repository) : IProductService
{
    public async Task<IReadOnlyList<ProductDto>> GetAllAsync(CancellationToken ct = default) =>
        (await repository.GetAllAsync(ct)).Select(ToDto).ToList();

    public async Task<ProductDto> GetByIdAsync(int id, CancellationToken ct = default) =>
        ToDto(await repository.GetByIdAsync(id, ct) ?? throw new NotFoundException(nameof(Product), id));

    public async Task<ProductDto> CreateAsync(CreateProductRequest request, CancellationToken ct = default)
    {
        var product = new Product
        {
            Name = request.Name,
            Sku = request.Sku,
            Price = request.Price,
            StockQuantity = request.StockQuantity,
            CategoryId = request.CategoryId
        };
        await repository.AddAsync(product, ct);
        await repository.SaveChangesAsync(ct);
        return ToDto(product);
    }

    public async Task DeleteAsync(int id, CancellationToken ct = default)
    {
        var product = await repository.GetByIdAsync(id, ct) ?? throw new NotFoundException(nameof(Product), id);
        repository.Remove(product);
        await repository.SaveChangesAsync(ct);
    }

    private static ProductDto ToDto(Product p) =>
        new(p.Id, p.Name, p.Sku, p.Price, p.StockQuantity, p.CategoryId);
}
