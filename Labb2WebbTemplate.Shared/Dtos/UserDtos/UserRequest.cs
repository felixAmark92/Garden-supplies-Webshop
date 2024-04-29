using Labb2WebbTemplate.Shared.Dtos.AddressDtos;

namespace Labb2WebbTemplate.Shared.Dtos.UserDtos;

public record UserRequest(
    string FirstName,
    string LastName,
    string Email,
    string Phone,
    string Password,
    AddressRequest Address,
    int Id = 0,
    bool IsAdmin = false
);