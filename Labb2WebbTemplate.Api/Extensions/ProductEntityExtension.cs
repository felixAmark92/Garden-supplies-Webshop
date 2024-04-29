using Labb2WebbTemplate.Shared.Dtos.ProductDtos;
using Labb2WebbTemplate.StoreDataAccess.Entities;

namespace Labb2WebbTemplate.Api.Extensions;

public static class ProductEntityExtension
{
    public static ProductResponse ToProductResponse(this ProductEntity productEntity)
    {
        return new ProductResponse(
            productEntity.Id,
            productEntity.Name,
            productEntity.Description,
            productEntity.Price,
            productEntity.Category.ToDto(),
            productEntity.Stock,
            productEntity.IsDiscontinued,
            productEntity.ImagePath is not null
        );
    }
}