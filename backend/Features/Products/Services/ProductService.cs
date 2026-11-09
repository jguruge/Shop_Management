using Microsoft.EntityFrameworkCore;
using ShopManagement.Api.Data;
using ShopManagement.Api.Domain;
using ShopManagement.Api.Features.Products.DTOs;
using ShopManagement.Api.Features.Shared.Exceptions;

namespace ShopManagement.Api.Features.Products.Services;

public class ProductService(AppDbContext db) : IProductService
{
    public async Task<IReadOnlyList<ProductDto>> GetAllAsync(CancellationToken ct = default) =>
        await db.Products.AsNoTracking().Select(p => ToDto(p)).ToListAsync(ct);

    public async Task<ProductDto> GetByIdAsync(int id, CancellationToken ct = default) =>
        ToDto(await db.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id, ct)
              ?? throw new NotFoundException(nameof(Product), id));

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
        db.Products.Add(product);
        await db.SaveChangesAsync(ct);
        return ToDto(product);
    }

    public async Task DeleteAsync(int id, CancellationToken ct = default)
    {
        var product = await db.Products.FirstOrDefaultAsync(p => p.Id == id, ct)
                      ?? throw new NotFoundException(nameof(Product), id);
        db.Products.Remove(product);
        await db.SaveChangesAsync(ct);
    }

    private static ProductDto ToDto(Product p) =>
        new(p.Id, p.Name, p.Sku, p.Price, p.StockQuantity, p.CategoryId);
}
