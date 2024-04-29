namespace Labb2WebbTemplate.Shared.Dtos.AddressDtos;

public record AddressRequest(
    int CityId,
    string Address,
    string PostalCode
);