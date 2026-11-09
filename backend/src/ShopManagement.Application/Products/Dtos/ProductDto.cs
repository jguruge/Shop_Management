namespace ShopManagement.Application.Products.Dtos;

public record ProductDto(int Id, string Name, string? Sku, decimal Price, int StockQuantity, int? CategoryId);

public record CreateProductRequest(string Name, string? Sku, decimal Price, int StockQuantity, int? CategoryId);
