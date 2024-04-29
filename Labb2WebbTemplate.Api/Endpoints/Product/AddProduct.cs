using FastEndpoints;
using Labb2WebbTemplate.Shared.Dtos.ProductDtos;
using Labb2WebbTemplate.StoreDataAccess;
using Labb2WebbTemplate.StoreDataAccess.Entities;

namespace Labb2WebbTemplate.Api.Endpoints.Product;

public class AddProduct(UnitOfWork unit) 
    : Endpoint<ProductRequest, int>
{
    public override void Configure()
    {
        Post("/");
        Group<ProductGroup>();
    }

    public override async Task HandleAsync(ProductRequest req, CancellationToken ct)
    {
        
        var category = await unit.Categories.GetByIdAsync(req.CategoryId);

        if (category is null)
        {
            AddError(ErrorMessages.NotFound("categoryId", req.CategoryId));

            await SendErrorsAsync(404, ct);
            return;
        }

        var product = new ProductEntity()
        {
            Category = category,
            IsDiscontinued = req.IsDiscontinued,
            Description = req.Description,
            Name = req.Name,
            Price = req.Price,
        };

        await unit.Products.AddAsync(product);
        unit.SaveChanges();

        await SendOkAsync(product.Id, ct);
    }
}