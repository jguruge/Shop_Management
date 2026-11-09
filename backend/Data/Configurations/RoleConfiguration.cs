using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Api.Domain;

namespace ShopManagement.Api.Data.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    private static readonly DateTime SeedDate = new(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc);

    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.Property(r => r.Name).HasMaxLength(50).IsRequired();
        builder.Property(r => r.Description).HasMaxLength(200);
        builder.HasIndex(r => r.Name).IsUnique();

        builder.HasData(
            new Role { Id = 1, Name = Role.Admin, Description = "Full system access", CreatedAt = SeedDate },
            new Role { Id = 2, Name = Role.Manager, Description = "Manage products, stock and reports", CreatedAt = SeedDate },
            new Role { Id = 3, Name = Role.Cashier, Description = "Process sales", CreatedAt = SeedDate });
    }
}
