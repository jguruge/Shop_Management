namespace ShopManagement.Api.Features.Products.DTOs;

public record ProductDto(int Id, string Name, string? Sku, decimal Price, int StockQuantity, int? CategoryId);

public record CreateProductRequest(string Name, string? Sku, decimal Price, int StockQuantity, int? CategoryId);
