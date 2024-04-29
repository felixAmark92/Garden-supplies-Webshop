using FastEndpoints;

namespace Labb2WebbTemplate.Api.Endpoints.Category;

public sealed class CategoryGroup : Group
{
    public CategoryGroup()
    {
        Configure("category", definition =>
        {
            //definition.Roles("admin");
            definition.AllowAnonymous();
        } );
    }
}