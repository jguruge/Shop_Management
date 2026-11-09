using ShopManagement.Domain.Common;

namespace ShopManagement.Application.Common.Interfaces;

public interface IRepository<T> where T : BaseEntity
{
    Task<IReadOnlyList<T>> GetAllAsync(CancellationToken ct = default);
    Task<T?> GetByIdAsync(int id, CancellationToken ct = default);
    Task AddAsync(T entity, CancellationToken ct = default);
    void Update(T entity);
    void Remove(T entity);
    Task SaveChangesAsync(CancellationToken ct = default);
}
