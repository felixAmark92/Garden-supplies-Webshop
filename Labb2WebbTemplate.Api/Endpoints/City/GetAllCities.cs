using FastEndpoints;
using Labb2WebbTemplate.Shared.Dtos.CityDtos;
using Labb2WebbTemplate.Shared.Dtos.RegionDtos;
using Labb2WebbTemplate.StoreDataAccess;

namespace Labb2WebbTemplate.Api.Endpoints.City;

public class GetAllCities(UnitOfWork unit) 
    : Endpoint<EmptyRequest, IEnumerable<CityResponse>>
{
    public override void Configure()
    {
        Get("/");
        Group<CityGroup>();
    }

    public override async Task HandleAsync(EmptyRequest req, CancellationToken ct)
    {
        var cities = await unit.Cities.GetAllAsync();

        var result = cities.Select(c => 
            new CityResponse(c.Id, c.Name, new RegionResponse(c.Region.Id , c.Region.Name)));

        await SendOkAsync(result, ct);
    }
}