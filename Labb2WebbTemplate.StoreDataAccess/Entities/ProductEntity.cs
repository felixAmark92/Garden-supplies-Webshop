using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Labb2WebbTemplate.Shared.Enums;
using Labb2WebbTemplate.StoreDataAccess.Interfaces;

namespace Labb2WebbTemplate.StoreDataAccess.Entities;

public class ProductEntity : IEntity<int, ProductEntity>
{
    public int Id { get; set; }

    [StringLength(50)]
    public string Name { get; set; } = string.Empty;
    
    [StringLength(500)]
    [Column(TypeName = "TEXT")]
    public string Description { get; set; } = string.Empty;
    public double Price { get; set; }
    public CategoryEntity Category { get; set; } = null!;
    public int Stock { get; set; }
    public bool IsDiscontinued { get; set; }
    
    public List<ProductOrderEntity> Orders { get; set; } = null!;
    
    [StringLength(200)]
    public string? ImagePath { get; set; }
    
    public void Update(ProductEntity updatedEntity)
    {
        Name = updatedEntity.Name;
        Description = updatedEntity.Description;
        Price = updatedEntity.Price;
        Category = updatedEntity.Category;
        IsDiscontinued = updatedEntity.IsDiscontinued;
    }
}