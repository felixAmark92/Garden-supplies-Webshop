using FastEndpoints;
using Labb2WebbTemplate.Api.Extensions;
using Labb2WebbTemplate.Shared.Dtos.ProductDtos;
using Labb2WebbTemplate.StoreDataAccess;

namespace Labb2WebbTemplate.Api.Endpoints.Product;

public class GetAllProducts(UnitOfWork unit) 
    : Endpoint<EmptyRequest, IEnumerable<ProductResponse>>
{
    public override void Configure()
    {
        Get("/");
        Group<ProductGroup>();
    }

    public override async Task HandleAsync(EmptyRequest req, CancellationToken ct)
    {
        var products = await unit.Products.GetAllAsync();

        var response = products.Select(p => p.ToProductResponse());

        await SendOkAsync(response, ct);
    }
}