using Labb2WebbTemplate.Shared.Dtos.CityDtos;

namespace Labb2WebbTemplate.Api.Endpoints.User;

public record AddressResponse(
    string Address, 
    string PostalCode, 
    CityResponse City);