using Labb2WebbTemplate.Shared.Dtos.CategoryDtos;
using Labb2WebbTemplate.Shared.Enums;

namespace Labb2WebbTemplate.Shared.Dtos.ProductDtos;

public record ProductResponse(
    int Id, 
    string Name, 
    string Description, 
    double Price,
    CategoryResponse Category,
    int Stock,
    bool IsDiscontinued,
    bool HasImage = false);