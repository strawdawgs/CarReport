using EntityFrameworkAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using DataModelLibrary.Specifications;

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

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await db.Set<T>().ToListAsync();
    }

    public async Task<T?> FindBySpecificationAsync(BaseSpecification<T> spec)
    {
        return await BuildQuery(spec).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<T>> ListBySpecificationAsync(BaseSpecification<T> spec)
    {
        return await BuildQuery(spec).ToListAsync();
    }

    public IQueryable<T> QueryBySpecification(BaseSpecification<T> spec)
    {
        return BuildQuery(spec).AsNoTracking();
    }

    private IQueryable<T> BuildQuery(BaseSpecification<T> spec)
    {
        var query = db.Set<T>().AsQueryable();

        if (spec.Criteria != null)
            query = query.Where(spec.Criteria);

        if (spec.Includes != null)
        {
            foreach (var include in spec.Includes)
                query = query.Include(include);
        }

        return query;
    }
}
