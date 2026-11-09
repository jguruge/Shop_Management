namespace ShopManagement.Api.Domain;

public class Category : BaseEntity
{
    public required string Name { get; set; }
    public ICollection<Product> Products { get; set; } = [];
}
