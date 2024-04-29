using FastEndpoints;

namespace Labb2WebbTemplate.Api.Endpoints.User;

public sealed class UserGroupAnonymous : Group
{
    public UserGroupAnonymous()
    {
        Configure("user", definition =>
        {
            definition.AllowAnonymous();
        });
    }
}