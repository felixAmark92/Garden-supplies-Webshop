namespace Labb2WebbTemplate.StoreDataAccess.Interfaces;

public interface IEntity<TId, in TEntity>
{
    public TId Id { get; set; }
    public void Update(TEntity updatedEntity);
}