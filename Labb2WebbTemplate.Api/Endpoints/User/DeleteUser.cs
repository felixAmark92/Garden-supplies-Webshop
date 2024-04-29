using FastEndpoints;
using Labb2WebbTemplate.Shared.Enums;
using Labb2WebbTemplate.StoreDataAccess;

namespace Labb2WebbTemplate.Api.Endpoints.User;

public record DeleteUserRequest(int Id);

public class DeleteUser(UnitOfWork unit) 
    : Endpoint<DeleteUserRequest, EmptyResponse>
{
    public override void Configure()
    {
        Delete("id/{id}");
        Group<UserGroupUser>();
    }

    public override async Task HandleAsync(DeleteUserRequest req, CancellationToken ct)
    {
        var user = User.Claims.Single(c => c.Type == "userId");
        var userId = int.Parse(user.Value);

        if (userId != req.Id && !User.IsInRole("admin"))
        {
            await SendForbiddenAsync(ct);
            return;
        }

        var result = await unit.Users.DeleteAsync(req.Id);

        if (result == RepositoryStatus.NotFound)
        {
            AddError("User could not be found");

            await SendErrorsAsync(404, ct);
            return;
        }
        unit.SaveChanges();
        await SendOkAsync(ct);
    }
}