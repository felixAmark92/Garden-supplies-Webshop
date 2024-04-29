using FastEndpoints;
using Labb2WebbTemplate.Api.Endpoints.Product;
using Labb2WebbTemplate.Shared.Dtos.CityDtos;
using Labb2WebbTemplate.Shared.Dtos.RegionDtos;
using Labb2WebbTemplate.StoreDataAccess;

namespace Labb2WebbTemplate.Api.Endpoints.User;

public class GetUserAddress(UnitOfWork unitOfWork) : Endpoint<IdRequest, AddressResponse>
{
    public override void Configure()
    {
        Get("/{id}/Address");
        Group<UserGroupUser>();
    }

    public override async Task HandleAsync(IdRequest req, CancellationToken ct)
    {
        var user = await unitOfWork.Users.GetByIdAsync(req.Id);

        if (user is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        var region = new RegionResponse(user.Address.City.Region.Id, user.Address.City.Region.Name);
        var city = new CityResponse(user.Address.City.Id, user.Address.City.Name, region);
        
        var response = new AddressResponse(
            user.Address.Street, 
            user.Address.PostalCode,
            city);

        await SendOkAsync(response, ct);
    }

}