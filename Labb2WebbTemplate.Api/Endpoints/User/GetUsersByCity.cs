using FastEndpoints;
using Labb2WebbTemplate.Api.Extensions;
using Labb2WebbTemplate.Shared.Dtos.UserDtos;
using Labb2WebbTemplate.StoreDataAccess;

namespace Labb2WebbTemplate.Api.Endpoints.User;

public class GetUsersByCity
    (UnitOfWork unit) 
    : Endpoint<int, IEnumerable<UserResponse>>
{
    public override void Configure()
    {
        Get("/city");
        Group<UserGroupAdmin>();
        
    }

    public override async Task HandleAsync(int req, CancellationToken ct)
    {
        var users = await unit.Users.GetByCityAsync(req);
        var response = users.Select(u => u.ToUserResponse());
        await SendOkAsync(response, ct);

    }

}