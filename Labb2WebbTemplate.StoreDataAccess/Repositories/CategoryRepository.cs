using Labb2WebbTemplate.StoreDataAccess.Entities;

namespace Labb2WebbTemplate.StoreDataAccess.Repositories;

public class CategoryRepository(StoreDbContext context) 
    : Repository<CategoryEntity, int>(context)
{
}