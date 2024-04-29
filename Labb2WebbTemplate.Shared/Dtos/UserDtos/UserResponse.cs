namespace Labb2WebbTemplate.Shared.Dtos.UserDtos;

public record UserResponse(
    int Id,
    string FirstName,
    string LastName,
    string Email,
    string Phone,
    string Address
);
    
