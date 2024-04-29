using FastEndpoints;

namespace Labb2WebbTemplate.Api.Endpoints.Region;

public sealed class RegionGroup : Group
{
    public RegionGroup()
    {
        Configure("/region", definition => {definition.AllowAnonymous();});
    }
}