using FastEndpoints;

namespace Labb2WebbTemplate.Api.Endpoints.User;

public class AuthorizeUser() : Endpoint<EmptyRequest, int>
{
    public override void Configure()
    {
        Get("/authorize");
        Group<UserGroupUser>();
    }

    public override async Task HandleAsync(EmptyRequest req, CancellationToken ct)
    {
        var test = User.Claims.Single(c => c.Type == "userId");
        
        await SendOkAsync(int.Parse(test.Value), ct);
        
    }
}