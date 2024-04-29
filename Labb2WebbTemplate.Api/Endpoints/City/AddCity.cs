using FastEndpoints;
using Labb2WebbTemplate.Shared.Dtos.CityDtos;
using Labb2WebbTemplate.Shared.Enums;
using Labb2WebbTemplate.StoreDataAccess;
using Labb2WebbTemplate.StoreDataAccess.Entities.Address;

namespace Labb2WebbTemplate.Api.Endpoints.City;

public class AddCity(UnitOfWork unit) 
    : Endpoint<CityRequest, EmptyResponse>
{
    public override void Configure()
    {
        Post("/");
        Group<CityGroup>();
    }

    public override async Task HandleAsync(CityRequest req, CancellationToken ct)
    {
        
        var region = await unit.Regions.GetByIdAsync(req.RegionId);

        if (region is null)
        {
            AddError("invalid region id");

            await SendErrorsAsync(cancellation: ct);
            return;
        }
        
        var result = await unit.Cities.AddAsync(new CityEntity()
        {
            Name = req.Name,
            Region = region
        });

        if (result != RepositoryStatus.Ok)
        {
            await SendErrorsAsync(cancellation: ct);
            return;
        }

        unit.SaveChanges();
        await SendOkAsync(ct);
    }

}