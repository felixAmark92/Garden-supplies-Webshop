using FastEndpoints;

namespace Labb2WebbTemplate.Api.Endpoints.City;

public sealed class CityGroup : Group
{
    public CityGroup()
    {
        Configure("/city", definition =>{ definition.AllowAnonymous();} );
    }
}