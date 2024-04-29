using FastEndpoints;
using Labb2WebbTemplate.Api.Extensions;
using Labb2WebbTemplate.Shared.Dtos.UserDtos;
using Labb2WebbTemplate.StoreDataAccess;
using Microsoft.AspNetCore.Authentication;

namespace Labb2WebbTemplate.Api.Endpoints.User;

public class GetAllUsers(UnitOfWork unit) 
    : Endpoint<EmptyRequest, IEnumerable<UserResponse>>
{
    public override void Configure()
    {
        Get("/");
        Group<UserGroupAdmin>();
        
    }

    public override async Task HandleAsync(EmptyRequest req, CancellationToken ct)
    {
        var limit = Query<int>("limit", false);
        var page = Query<int>("page", false);

        if (limit != 0)
        {
            var userEntitiesLimited = await unit.Users.GetByRangeAsync(limit, page);
            await SendOkAsync(userEntitiesLimited.Select(u => u.ToUserResponse()), ct);
            
            return;
        }
        
        var userEntities = await unit.Users.GetAllAsync();
    
        var userResult = userEntities.Select(u => u.ToUserResponse());

         await SendOkAsync(userResult, ct);

    }
}