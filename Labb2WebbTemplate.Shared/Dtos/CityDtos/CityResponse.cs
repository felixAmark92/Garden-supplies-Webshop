using Labb2WebbTemplate.Shared.Dtos.RegionDtos;

namespace Labb2WebbTemplate.Shared.Dtos.CityDtos;

public record CityResponse(
    int Id, 
    string Name, 
    RegionResponse Region
);