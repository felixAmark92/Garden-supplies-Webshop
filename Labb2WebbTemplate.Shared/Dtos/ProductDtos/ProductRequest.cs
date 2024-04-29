using Labb2WebbTemplate.Shared.Enums;

namespace Labb2WebbTemplate.Shared.Dtos.ProductDtos;

public record ProductRequest(
    string Name,
    string Description,
    double Price,
    int CategoryId,
    bool IsDiscontinued = false,
    int Stock = 0,
    int Id = 0);
