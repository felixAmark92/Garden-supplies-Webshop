using Labb2WebbTemplate.StoreDataAccess.Entities.Address;

namespace Labb2WebbTemplate.StoreDataAccess.Repositories;

public class CityRepository(StoreDbContext context) 
    : Repository<CityEntity, int>(context)
{
}