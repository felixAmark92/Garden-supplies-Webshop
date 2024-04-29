using FastEndpoints;
using Labb2WebbTemplate.Shared.Enums;
using Labb2WebbTemplate.StoreDataAccess;

namespace Labb2WebbTemplate.Api.Endpoints.Category;

public record DeleteCategoryRequest(int id);

public class DeleteCategory(UnitOfWork unit) 
    : Endpoint<DeleteCategoryRequest, EmptyResponse>
{
    public override void Configure()
    {
        Delete("/{id}");
        Group<CategoryGroup>();
    }

    public override async Task HandleAsync(DeleteCategoryRequest req, CancellationToken ct)
    {
        var result = await unit.Categories.DeleteAsync(req.id);

        if (result == RepositoryStatus.NotFound)
        {
            AddError("The provided id did not map with a category");
            await SendErrorsAsync(404, ct);
            return;
        }
        
        unit.SaveChanges();
        await SendStringAsync("Category has been deleted", 200,  cancellation: ct);
    }
}