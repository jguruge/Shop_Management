namespace ShopManagement.Api.Domain;

public class Sale : BaseEntity
{
    public int? CustomerId { get; set; }
    public Customer? Customer { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public decimal TotalAmount { get; set; }
    public ICollection<SaleItem> Items { get; set; } = [];
}
