using ShopManagement.Application.Common.Exceptions;
using ShopManagement.Application.Common.Interfaces;
using ShopManagement.Application.Products;
using ShopManagement.Domain.Entities;

namespace ShopManagement.UnitTests.Products;

public class ProductServiceTests
{
    [Fact]
    public async Task GetByIdAsync_Throws_WhenProductMissing()
    {
        var service = new ProductService(new InMemoryRepository());
        await Assert.ThrowsAsync<NotFoundException>(() => service.GetByIdAsync(1));
    }

    private sealed class InMemoryRepository : IRepository<Product>
    {
        private readonly List<Product> _items = [];
        public Task<IReadOnlyList<Product>> GetAllAsync(CancellationToken ct = default) => Task.FromResult<IReadOnlyList<Product>>(_items);
        public Task<Product?> GetByIdAsync(int id, CancellationToken ct = default) => Task.FromResult(_items.FirstOrDefault(p => p.Id == id));
        public Task AddAsync(Product entity, CancellationToken ct = default) { _items.Add(entity); return Task.CompletedTask; }
        public void Update(Product entity) { }
        public void Remove(Product entity) => _items.Remove(entity);
        public Task SaveChangesAsync(CancellationToken ct = default) => Task.CompletedTask;
    }
}
