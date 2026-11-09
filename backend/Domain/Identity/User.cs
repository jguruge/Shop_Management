namespace ShopManagement.Api.Domain;

public class User : BaseEntity
{
    public required string Username { get; set; }
    public required string Email { get; set; }
    public required string FullName { get; set; }
    public string PasswordHash { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
    public DateTime? LastLoginAt { get; set; }

    public int RoleId { get; set; }
    public Role Role { get; set; } = null!;
}
