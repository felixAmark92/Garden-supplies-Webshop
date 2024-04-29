using FastEndpoints;

namespace Labb2WebbTemplate.Api.Endpoints.Product;

public sealed class ProductGroup : Group
{
    public ProductGroup()
    {
        Configure("product", definition =>
        {
            definition.AllowAnonymous();
        });
    }
}