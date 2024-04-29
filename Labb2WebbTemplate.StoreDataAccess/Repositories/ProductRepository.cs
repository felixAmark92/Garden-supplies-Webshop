using System.Text.RegularExpressions;
using Labb2WebbTemplate.Shared.Enums;
using Labb2WebbTemplate.StoreDataAccess.Entities;

namespace Labb2WebbTemplate.StoreDataAccess.Repositories;

public class ProductRepository(StoreDbContext context) 
    : Repository<ProductEntity, int>(context)
{

    public async Task<IEnumerable<ProductEntity>> GetByCategory(CategoryEntity category)
    {
        return context.Set<ProductEntity>().Where(p => p.Category == category);
    }

    public async Task<IEnumerable<ProductEntity>> GetBySearch(string query)
    {
        var test = context.Set<ProductEntity>().Where(p => 
            p.Name.ToLower().Contains(query));

        return test;
    }
    
    public async Task<RepositoryStatus> AddToStock(int id, int amount)
    {
        var product = await context.Products.FindAsync(id);
        if (product is null)
        {
            return RepositoryStatus.NotFound;
        }

        product.Stock += amount;

        return RepositoryStatus.Ok;
    }
    public async Task<RepositoryStatus> RemoveFromStock(int id, int amount)
    {
        var product = await context.Products.FindAsync(id);
        if (product is null)
        {
            return RepositoryStatus.NotFound;
        }

        product.Stock -= amount;

        if (product.Stock  < 0)
        {
            return RepositoryStatus.BadRequest;
        }

        return RepositoryStatus.Ok;
    }
}