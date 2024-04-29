using FastEndpoints;
using Labb2WebbTemplate.StoreDataAccess;

namespace Labb2WebbTemplate.Api.Endpoints.Product;

public class DeleteProduct(UnitOfWork unit) : Endpoint<IdRequest, EmptyResponse>
{
    public override void Configure()
    {
        Delete("/id/{Id}");
        Group<ProductGroup>();
        
    }

    public override async Task HandleAsync(IdRequest req, CancellationToken ct)
    {
        await unit.Products.DeleteAsync(req.Id);
        
        unit.SaveChanges();
    }
}