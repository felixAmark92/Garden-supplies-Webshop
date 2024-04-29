using Labb2WebbTemplate.Shared.Enums;
using Labb2WebbTemplate.StoreDataAccess.Interfaces;

namespace Labb2WebbTemplate.StoreDataAccess.Repositories;

public abstract class Repository<TEntity, TId>(StoreDbContext context) 
    : IRepository<TEntity, TId> where TEntity : class, IEntity<TId, TEntity>
{
    public virtual async Task<TEntity?> GetByIdAsync(TId id)
    {
        return await context.FindAsync<TEntity>(id);
    }
    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return context.Set<TEntity>();
    }
    public virtual async Task<IEnumerable<TEntity>> GetByRangeAsync(int range, int page)
    {
        var entities = 
            context.Set<TEntity>()
                .Take(range)
                .Skip(range * page);
        return entities;
    }
    public virtual async Task<RepositoryStatus> AddAsync(TEntity entity)
    {
        var test = await context.AddAsync(entity);

        var moreTest = test.Entity.Id;

        return RepositoryStatus.Ok;
    }

    public virtual async Task<RepositoryStatus> UpdateAsync(TId id, TEntity newEntity)
    {
        var entity = await context.FindAsync<TEntity>(id);

        if (entity is null)
        {
            return RepositoryStatus.NotFound;
        }
        entity.Update(newEntity);

        context.Update(entity);

        return RepositoryStatus.Ok;
    }
    public virtual async Task<RepositoryStatus> DeleteAsync(TId id)
    {
        var entity = await context.FindAsync<TEntity>(id);

        if (entity is null)
        {
            return RepositoryStatus.NotFound;
        }
        context.Remove(entity);
        return RepositoryStatus.Ok;
    }
}