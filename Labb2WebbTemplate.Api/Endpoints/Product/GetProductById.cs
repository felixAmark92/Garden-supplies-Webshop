using FastEndpoints;
using Labb2WebbTemplate.Api.Extensions;
using Labb2WebbTemplate.Shared.Dtos.ProductDtos;
using Labb2WebbTemplate.StoreDataAccess;

namespace Labb2WebbTemplate.Api.Endpoints.Product;

public class GetProductById(UnitOfWork unit) 
    : Endpoint<IdRequest, ProductResponse>
{
    public override void Configure()
    {
        Get("id/{id}");
        Group<ProductGroup>();
    }

    public override async Task HandleAsync(IdRequest req, CancellationToken ct)
    {
        var product = await unit.Products.GetByIdAsync(req.Id);

        if (product is null)
        {
            AddError(ErrorMessages.NotFound("id", req.Id));

            await SendErrorsAsync(cancellation: ct);
            return;
        }
        var response = product.ToProductResponse();
        await SendOkAsync(response, ct);

    }

}