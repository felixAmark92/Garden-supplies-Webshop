using Labb2WebbTemplate.Shared.Dtos.CategoryDtos;
using Labb2WebbTemplate.StoreDataAccess.Entities;

namespace Labb2WebbTemplate.Api.Extensions;

public static class CategoryEntityExtensions
{
    public static CategoryResponse ToDto(this CategoryEntity category)
    {
        return new CategoryResponse(category.Id, category.Name);
    }
}