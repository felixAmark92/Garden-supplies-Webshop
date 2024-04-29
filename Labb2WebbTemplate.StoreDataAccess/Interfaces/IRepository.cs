using Labb2WebbTemplate.Shared.Enums;

namespace Labb2WebbTemplate.StoreDataAccess.Interfaces;

public interface IRepository<TEntity, in TId> where TEntity : IEntity<TId, TEntity>
{
    Task<TEntity?> GetByIdAsync(TId id);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<RepositoryStatus> AddAsync(TEntity entity);
    Task<RepositoryStatus> UpdateAsync(TId id, TEntity newEntity);
    Task<RepositoryStatus> DeleteAsync(TId id);
}