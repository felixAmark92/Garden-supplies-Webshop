using FastEndpoints;
using Labb2WebbTemplate.Shared.Dtos.RegionDtos;
using Labb2WebbTemplate.StoreDataAccess;

namespace Labb2WebbTemplate.Api.Endpoints.Region;

public class GetAllRegions(UnitOfWork unit) 
    : Endpoint<EmptyRequest, IEnumerable<RegionResponse>>
{
    public override void Configure()
    {
        Get("/");
        Group<RegionGroup>();
    }

    public override async Task HandleAsync(EmptyRequest req, CancellationToken ct)
    {
        var regions = await unit.Regions.GetAllAsync();

        var response = regions.Select(r => new RegionResponse(r.Id, r.Name));

        await SendOkAsync(response, ct );
    }
}