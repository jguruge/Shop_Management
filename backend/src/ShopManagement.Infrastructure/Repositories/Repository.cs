using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Common.Interfaces;
using ShopManagement.Domain.Common;
using ShopManagement.Infrastructure.Persistence;

namespace ShopManagement.Infrastructure.Repositories;

public class Repository<T>(AppDbContext db) : IRepository<T> where T : BaseEntity
{
    public async Task<IReadOnlyList<T>> GetAllAsync(CancellationToken ct = default) =>
        await db.Set<T>().AsNoTracking().ToListAsync(ct);

    public Task<T?> GetByIdAsync(int id, CancellationToken ct = default) =>
        db.Set<T>().FirstOrDefaultAsync(e => e.Id == id, ct);

    public async Task AddAsync(T entity, CancellationToken ct = default) =>
        await db.Set<T>().AddAsync(entity, ct);

    public void Update(T entity) => db.Set<T>().Update(entity);

    public void Remove(T entity) => db.Set<T>().Remove(entity);

    public Task SaveChangesAsync(CancellationToken ct = default) => db.SaveChangesAsync(ct);
}
