using FastEndpoints;
using Labb2WebbTemplate.StoreDataAccess;
using Labb2WebbTemplate.StoreDataAccess.Entities;

namespace Labb2WebbTemplate.Api.Endpoints.Category;


public class AddCategory(UnitOfWork unit) 
    : Endpoint<string, EmptyResponse>
{
    public override void Configure()
    {
        Post("/");
        Group<CategoryGroup>();
    }

    public override async Task HandleAsync(string req, CancellationToken ct)
    {
        await unit.Categories.AddAsync(new CategoryEntity() { Name = req });
        unit.SaveChanges();

        await SendStringAsync("Category was added", cancellation: ct);
    }
}