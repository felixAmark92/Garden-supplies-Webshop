using FastEndpoints;
using Labb2WebbTemplate.Api.Endpoints.Product;
using Labb2WebbTemplate.Api.Extensions;
using Labb2WebbTemplate.Shared.Dtos.UserDtos;
using Labb2WebbTemplate.StoreDataAccess;

namespace Labb2WebbTemplate.Api.Endpoints.User;


public class GetUserByEmail(UnitOfWork unit) 
    : Endpoint<StringRequest, UserResponse>
{
    public override void Configure()
    {
        Get("/email/{value}");
        Group<UserGroupAnonymous>();
    }

    public override async Task HandleAsync(StringRequest req, CancellationToken ct)
    {
        var user = await unit.Users.GetByEmailAsync(req.Value);

        if (user is null)
        {
            AddError("User was not found");
            await SendErrorsAsync(cancellation: ct);
            
            return;
        }

        var response = user.ToUserResponse();
        await SendOkAsync(response, ct);

    }

}