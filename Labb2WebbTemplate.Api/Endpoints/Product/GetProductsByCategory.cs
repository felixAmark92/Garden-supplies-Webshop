using FastEndpoints;
using Labb2WebbTemplate.Api.Extensions;
using Labb2WebbTemplate.Shared.Dtos.ProductDtos;
using Labb2WebbTemplate.StoreDataAccess;

namespace Labb2WebbTemplate.Api.Endpoints.Product;

public class GetProductsByCategory(UnitOfWork unit) 
    : Endpoint<IdRequest, IEnumerable<ProductResponse>>
{
    public override void Configure()
    {
        Get("category/{id}");                
        Group<ProductGroup>();
    }

    public override async Task HandleAsync(IdRequest req, CancellationToken ct)
    {
        var category = await unit.Categories.GetByIdAsync(req.Id);

        if (category is null)
        {
            AddError(ErrorMessages.NotFound("id", req.Id));
            await SendErrorsAsync(cancellation: ct);
            return;
        }

        var products = await unit.Products.GetByCategory(category);

        var result = products.Select(p => p.ToProductResponse());

        await SendOkAsync(result, ct);
    }

}