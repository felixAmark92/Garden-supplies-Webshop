
using Labb2WebbTemplate.StoreDataAccess.Interfaces;

namespace Labb2WebbTemplate.StoreDataAccess.Entities;

public class OrderEntity : IEntity<int, OrderEntity>
{
    public int Id { get; set; }
    public UserEntity User { get; set; } = null!;
    public DateTime OrderDate { get; set; }
    public virtual List<ProductOrderEntity> Products { get; set; } = new();
    
    public void Update(OrderEntity updatedEntity)
    {
        throw new NotImplementedException();
    }
}