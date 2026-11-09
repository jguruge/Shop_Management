namespace ShopManagement.Api.Domain;

public class Role : BaseEntity
{
    public const string Admin = "Admin";
    public const string Manager = "Manager";
    public const string Cashier = "Cashier";

    public required string Name { get; set; }
    public string? Description { get; set; }
    public ICollection<User> Users { get; set; } = [];
}
