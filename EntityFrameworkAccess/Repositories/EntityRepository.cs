using EntityFrameworkAccess.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkAccess.Repositories;

public class EntityRepository<T>(CarMaintenanceDbContext appDbContext) where T : class
{
    protected readonly CarMaintenanceDbContext db = appDbContext;

    public async Task<T?> FindByIdAsync(int id)
    {
        return await db.Set<T>().FindAsync(id);
    }

    public async Task AddAsync(T entity)
    {
        await db.Set<T>().AddAsync(entity);
    }

    public Task DeleteAsync(T entity)
    {
        db.Set<T>().Remove(entity);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(T entity)
    {
        db.Set<T>().Update(entity);
        return Task.CompletedTask;
    }

    public async Task SaveChangesAsync()
    {
        await db.SaveChangesAsync();
    }

    public async Task<IEnumerable<T?>> GetAllAsync()
    {
        return await db.Set<T>().ToListAsync();
    }
}
