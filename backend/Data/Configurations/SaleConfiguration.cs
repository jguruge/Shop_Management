using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Api.Domain;

namespace ShopManagement.Api.Data.Configurations;

public class SaleConfiguration : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.Property(s => s.TotalAmount).HasPrecision(18, 2);
        builder.Property(s => s.PaymentMethod).HasConversion<string>().HasMaxLength(20);
    }
}

public class SaleItemConfiguration : IEntityTypeConfiguration<SaleItem>
{
    public void Configure(EntityTypeBuilder<SaleItem> builder) =>
        builder.Property(i => i.UnitPrice).HasPrecision(18, 2);
}
