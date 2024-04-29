using Labb2WebbTemplate.Shared.Dtos.UserDtos;
using Labb2WebbTemplate.StoreDataAccess.Entities;

namespace Labb2WebbTemplate.Api.Extensions;

public static class UserEntityExtensions
{
    public static UserResponse ToUserResponse(this UserEntity userEntity)
    {
        return new UserResponse(
            userEntity.Id,
            userEntity.FirstName,
            userEntity.LastName,
            userEntity.Email,
            userEntity.Phone,
            userEntity.Address.ToString()
        );
    }
    
}