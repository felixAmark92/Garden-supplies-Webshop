using FastEndpoints;
using Labb2WebbTemplate.Api.Extensions;
using Labb2WebbTemplate.Shared.Dtos.CategoryDtos;
using Labb2WebbTemplate.StoreDataAccess;

namespace Labb2WebbTemplate.Api.Endpoints.Category;

public class GetAllCategories(UnitOfWork unit) 
    : Endpoint<EmptyRequest, IEnumerable<CategoryResponse>>
{
    public override void Configure()
    {
        Get("/");
        Group<CategoryGroup>();
    }

    public override async Task HandleAsync(EmptyRequest req, CancellationToken ct)
    {
        var categories = await unit.Categories.GetAllAsync();

        var order = Query<string>("order", false);

        if (order is not null)
        {
            if (order == "alph")
            {
                categories = categories.OrderBy(c => c.Name);
            }
            if (order == "alph-desc")
            {
                categories = categories.OrderByDescending(c => c.Name);
            }
        }
        

        var response = categories.Select(c => c.ToDto());

        await SendOkAsync(response, ct);
    }
}