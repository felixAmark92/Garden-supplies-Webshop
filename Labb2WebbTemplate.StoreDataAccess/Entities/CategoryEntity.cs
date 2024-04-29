using System.ComponentModel.DataAnnotations;
using Labb2WebbTemplate.StoreDataAccess.Interfaces;

namespace Labb2WebbTemplate.StoreDataAccess.Entities;

public class CategoryEntity : IEntity<int, CategoryEntity>
{
    public int Id { get; set; }

    [StringLength(50)]
    public string Name { get; set; } = string.Empty;
    
    public void Update(CategoryEntity updatedEntity)
    {
        Name = updatedEntity.Name;
    }
}