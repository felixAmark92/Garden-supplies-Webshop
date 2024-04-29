using System.ComponentModel.DataAnnotations;
using Labb2WebbTemplate.StoreDataAccess.Interfaces;

namespace Labb2WebbTemplate.StoreDataAccess.Entities.Address;

public class RegionEntity :IEntity<int, RegionEntity>
{
    public int Id { get; set; }

    [StringLength(50)] 
    public string Name { get; set; } = string.Empty;

    public List<CityEntity> Cities { get; set; } = new();
    
    public void Update(RegionEntity updatedEntity)
    {
        Name = updatedEntity.Name;
    }

}