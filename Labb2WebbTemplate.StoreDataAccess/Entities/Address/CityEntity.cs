using System.ComponentModel.DataAnnotations;
using Labb2WebbTemplate.StoreDataAccess.Interfaces;

namespace Labb2WebbTemplate.StoreDataAccess.Entities.Address;

public class CityEntity : IEntity<int, CityEntity>
{
    public int Id { get; set; }

    [StringLength(50)] 
    public string Name { get; set; } = null!;
    public RegionEntity Region { get; set; } = null!;
    
    public void Update(CityEntity updatedEntity)
    {
        Name = updatedEntity.Name;
        Region = updatedEntity.Region;
    }
    
}