using FastEndpoints;
using Labb2WebbTemplate.Shared.Dtos.ProductDtos;
using Labb2WebbTemplate.Shared.Enums;
using Labb2WebbTemplate.StoreDataAccess;
using Labb2WebbTemplate.StoreDataAccess.Entities;

namespace Labb2WebbTemplate.Api.Endpoints.Product;

public class UpdateProduct(UnitOfWork unit) : Endpoint<ProductRequest, int>
{
    public override void Configure()
    {
        Patch("/");
        Group<ProductGroup>();
    }

    public override async Task HandleAsync(ProductRequest req, CancellationToken ct)
    {
        var product = await unit.Products.GetByIdAsync(req.Id);
        var category = await unit.Categories.GetByIdAsync(req.CategoryId);

        if (product is null)
        {
            AddError(ErrorMessages.NotFound("id", req.Id));
            await SendNotFoundAsync(ct);
            return;
        }

        if (category is null)
        {
            AddError(ErrorMessages.NotFound("categoryId", req.CategoryId));
            await SendNotFoundAsync(ct);
            return;
        }

        var productEntity = new ProductEntity()
        {
            Name = req.Name,
            Price = req.Price,
            Category = category,
            Description = req.Description,
            IsDiscontinued = req.IsDiscontinued
            
        };

        var response = await unit.Products.UpdateAsync(product.Id, productEntity);

        if (response != RepositoryStatus.Ok)
        {
            AddError("unexpected error");
            await SendErrorsAsync(cancellation: ct);
            return;
        }
        unit.SaveChanges();

        await SendOkAsync(product.Id, ct);

    }

}