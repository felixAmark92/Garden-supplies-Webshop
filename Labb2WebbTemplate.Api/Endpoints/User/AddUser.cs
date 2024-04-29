using FastEndpoints;
using Labb2WebbTemplate.Shared;
using Labb2WebbTemplate.Shared.Dtos.UserDtos;
using Labb2WebbTemplate.Shared.Enums;
using Labb2WebbTemplate.StoreDataAccess;
using Labb2WebbTemplate.StoreDataAccess.Entities;
using Labb2WebbTemplate.StoreDataAccess.Entities.Address;

namespace Labb2WebbTemplate.Api.Endpoints.User;

public class AddUser(UnitOfWork unit)   
    : Endpoint<UserRequest, EmptyResponse>
{
    public override void Configure()
    {
        Post("/");
        Group<UserGroupAnonymous>();
    }

    public override async Task HandleAsync(UserRequest req, CancellationToken ct)
    {
                
        if (await unit.Users.EmailIsRegistered(req.Email))
        {
            AddError("The provided email is already registered");
            await SendErrorsAsync(cancellation: ct);
            return;
        }

        var city = await unit.Cities.GetByIdAsync(req.Address.CityId);
        
        if (city is null)
        {
            AddError("city id could not be found");
            await SendErrorsAsync(cancellation: ct);
            return;
        }
        
        var address = new AddressEntity()
        {
            City = city,
            PostalCode = req.Address.PostalCode,
            Street = req.Address.Address,
        };
        var userEntity = new UserEntity()
        {
            FirstName   = req.FirstName,
            LastName = req.LastName,
            Email = req.Email,
            Phone = req.Phone,
            Address = address,
            IsAdmin = req.IsAdmin
        };
        address.User = userEntity;
        var salt = Cryptography.GenerateSalt();
        userEntity.Salt = salt;
        userEntity.Hash = Cryptography.CreateSha256Hash(req.Password, salt);
        
        var repositoryStatus = await unit.Users.AddAsync(userEntity);

        unit.SaveChanges();
        await SendOkAsync( ct);
    }
}