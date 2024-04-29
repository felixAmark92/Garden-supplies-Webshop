using FastEndpoints;
using Labb2WebbTemplate.Shared.Enums;
using Labb2WebbTemplate.StoreDataAccess;

namespace Labb2WebbTemplate.Api.Endpoints.Product;
 
public class AddToProductStock(UnitOfWork unit) : Endpoint<ProductStockRequest, EmptyResponse>
{
    public override void Configure()
    {
        Patch("/addToStock");
        Group<ProductGroup>();
    }

    public override async Task HandleAsync(ProductStockRequest req, CancellationToken ct)
    {
        var status = await unit.Products.AddToStock(req.ProductId, req.Amount);

        if (status == RepositoryStatus.NotFound)
        {
            AddError(ErrorMessages.NotFound("id", req.ProductId));
            await SendNotFoundAsync(ct);            
            return;
        }
        unit.SaveChanges();
        await SendOkAsync(ct);
    }

}