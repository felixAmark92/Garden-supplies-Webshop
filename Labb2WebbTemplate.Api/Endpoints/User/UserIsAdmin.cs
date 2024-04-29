using FastEndpoints;

namespace Labb2WebbTemplate.Api.Endpoints.User;

public class UserIsAdmin() : Endpoint<EmptyRequest, EmptyResponse>
{
    public override void Configure()
    {
        Get("/user/isAdmin");
        Roles("admin");
    }

    public override async Task HandleAsync(EmptyRequest req, CancellationToken ct)
    {
        await SendOkAsync(ct);
    }

}