using Labb2WebbTemplate.Shared.Enums;

namespace Labb2WebbTemplate.App.Services;

public interface IService<TModel, in TId>
{
    Task<TModel?> GetByIdAsync(TId id);
    Task<IEnumerable<TModel>> GetAllAsync();
    Task<RepositoryStatus> AddAsync(TModel entity);
    Task<RepositoryStatus> UpdateAsync(TId id, TModel newEntity);
    Task<RepositoryStatus> DeleteAsync(TId id);
}