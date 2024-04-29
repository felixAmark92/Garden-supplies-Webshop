using FastEndpoints;
using Labb2WebbTemplate.Api.Endpoints.Product;
using Labb2WebbTemplate.Api.Extensions;
using Labb2WebbTemplate.Shared.Dtos.CategoryDtos;
using Labb2WebbTemplate.StoreDataAccess;

namespace Labb2WebbTemplate.Api.Endpoints.Category;


public class GetCategoryById(UnitOfWork unit) 
    : Endpoint<IdRequest, CategoryResponse>
{
    public override void Configure()
    {
        Get("id/{id}");
        Group<CategoryGroup>();
    }
    public override async Task HandleAsync(IdRequest req, CancellationToken ct)
    {
        var category = await unit.Categories.GetByIdAsync(req.Id);
        if (category is null)
        {
            AddError(ErrorMessages.NotFound("id", req.Id));
            await SendErrorsAsync(404, ct);

            return;
        }
        
        var response = category.ToDto();
        await SendOkAsync(response, ct);
    }
}