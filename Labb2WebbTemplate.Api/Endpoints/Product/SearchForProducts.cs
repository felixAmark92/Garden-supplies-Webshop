using FastEndpoints;
using Labb2WebbTemplate.Api.Extensions;
using Labb2WebbTemplate.Shared.Dtos.ProductDtos;
using Labb2WebbTemplate.StoreDataAccess;

namespace Labb2WebbTemplate.Api.Endpoints.Product;

public class SearchForProducts(UnitOfWork unit) : Endpoint<StringRequest, IEnumerable<ProductResponse>>
{
    public override void Configure()
    {
        Get("/search/{value}");
        Group<ProductGroup>();
    }

    public override async Task HandleAsync(StringRequest req, CancellationToken ct)
    {
        var products = await unit.Products.GetBySearch(req.Value);
        var result = products.Select(p => p.ToProductResponse());
        await SendOkAsync(result, ct);
    }
}