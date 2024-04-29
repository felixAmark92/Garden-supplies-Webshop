using FastEndpoints;
using Labb2WebbTemplate.Api.Endpoints.Product;
using Labb2WebbTemplate.Api.Extensions;
using Labb2WebbTemplate.Shared.Dtos.UserDtos;
using Labb2WebbTemplate.StoreDataAccess;

namespace Labb2WebbTemplate.Api.Endpoints.User;

public class GetUserById(UnitOfWork unit)
    : Endpoint<IdRequest, UserResponse>
{
    public override void Configure()
    {
        Get("id/{id}");
        Group<UserGroupAnonymous>();
    }

    public override async Task HandleAsync(IdRequest req, CancellationToken ct)
    {
        var user = await unit.Users.GetByIdAsync(req.Id);

        if (user is null)
        {
            AddError(ErrorMessages.NotFound("id", req.Id));

            await SendNotFoundAsync(ct);
            return;
        }
        var response = user.ToUserResponse();
        await SendOkAsync(response, ct);
    }
}