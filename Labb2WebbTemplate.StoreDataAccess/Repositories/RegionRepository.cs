using Labb2WebbTemplate.StoreDataAccess.Entities.Address;

namespace Labb2WebbTemplate.StoreDataAccess.Repositories;

public class RegionRepository(StoreDbContext context) 
    : Repository<RegionEntity, int>(context)
{
}