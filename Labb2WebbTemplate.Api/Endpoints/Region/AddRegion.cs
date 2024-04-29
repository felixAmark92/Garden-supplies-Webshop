using FastEndpoints;
using Labb2WebbTemplate.StoreDataAccess;
using Labb2WebbTemplate.StoreDataAccess.Entities.Address;

namespace Labb2WebbTemplate.Api.Endpoints.Region;

public class AddRegion(UnitOfWork unit) 
    : Endpoint<string, EmptyResponse>
{
    public override void Configure()
    {
        Post("/");
        Group<RegionGroup>();
    }

    public override async Task HandleAsync(string req, CancellationToken ct)
    {
        var region = new RegionEntity()
        {
            Name = req
        };
        await unit.Regions.AddAsync(region);
        unit.SaveChanges();
    }

}