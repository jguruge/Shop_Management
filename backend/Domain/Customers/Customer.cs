namespace ShopManagement.Api.Domain;

public class Customer : BaseEntity
{
    public required string Name { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public ICollection<Sale> Sales { get; set; } = [];
}
