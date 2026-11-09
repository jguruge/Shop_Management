using ShopManagement.Api.Features.Products.DTOs;

namespace ShopManagement.Api.Features.Products.Services;

public interface IProductService
{
    Task<IReadOnlyList<ProductDto>> GetAllAsync(CancellationToken ct = default);
    Task<ProductDto> GetByIdAsync(int id, CancellationToken ct = default);
    Task<ProductDto> CreateAsync(CreateProductRequest request, CancellationToken ct = default);
    Task DeleteAsync(int id, CancellationToken ct = default);
}
