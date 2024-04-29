using Microsoft.EntityFrameworkCore;

namespace Labb2WebbTemplate.StoreDataAccess.Entities;

[PrimaryKey(nameof(ProductId), nameof(OrderId))]
public class ProductOrderEntity
{
    public int ProductId { get; set; }
    public int OrderId { get; set; }

    public ProductEntity Product { get; set; } = null!;
    public OrderEntity Order { get; set; } = null!;
    public int Amount { get; set; }
    public double Price { get; set; }
}