using ShopManagement.Domain.Common;
using ShopManagement.Domain.Enums;

namespace ShopManagement.Domain.Entities;

public class Sale : BaseEntity
{
    public int? CustomerId { get; set; }
    public Customer? Customer { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public decimal TotalAmount { get; set; }
    public ICollection<SaleItem> Items { get; set; } = [];
}
