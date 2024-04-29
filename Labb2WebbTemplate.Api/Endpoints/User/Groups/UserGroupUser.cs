using FastEndpoints;

namespace Labb2WebbTemplate.Api.Endpoints.User;

public sealed class UserGroupUser : Group
{
    public UserGroupUser()
    {
        Configure("user", definition =>
        {
            definition.AllowedRoles?.Add("user");
        });
    }
}