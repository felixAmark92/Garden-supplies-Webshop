using FastEndpoints;

namespace Labb2WebbTemplate.Api.Endpoints.User;

public sealed class UserGroupAdmin : Group
{
    public UserGroupAdmin()
    {
        Configure("user", definition =>
        {
            definition.Roles("admin");
        });
    }
}