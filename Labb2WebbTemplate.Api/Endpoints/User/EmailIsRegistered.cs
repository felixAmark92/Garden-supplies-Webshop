using FastEndpoints;
using Labb2WebbTemplate.Api.Endpoints.Product;
using Labb2WebbTemplate.StoreDataAccess;

namespace Labb2WebbTemplate.Api.Endpoints.User;

public class EmailIsRegistered(UnitOfWork unit) : Endpoint<StringRequest, bool>
{
    public override void Configure()
    {
        Get("/EmailIsRegistered/{value}");
        Group<UserGroupAnonymous>();
    }

    public override async Task HandleAsync(StringRequest req, CancellationToken ct)
    {
        var result = await unit.Users.EmailIsRegistered(req.Value);

        await SendOkAsync(result, ct);
    }

}