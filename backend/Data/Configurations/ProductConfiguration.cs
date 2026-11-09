using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Api.Domain;

namespace ShopManagement.Api.Data.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(p => p.Name).HasMaxLength(200).IsRequired();
        builder.Property(p => p.Sku).HasMaxLength(50);
        builder.HasIndex(p => p.Sku).IsUnique();
        builder.Property(p => p.Price).HasPrecision(18, 2);
    }
}
