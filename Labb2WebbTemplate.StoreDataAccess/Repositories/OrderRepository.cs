using Labb2WebbTemplate.StoreDataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Labb2WebbTemplate.StoreDataAccess.Repositories;

public class OrderRepository(StoreDbContext context) 
    : Repository<OrderEntity, int>(context)
{
    public async Task<IEnumerable<OrderEntity>?> GetOrdersByUserId(int id)
    {
        var user = await context.Users
            .Include(u => u.Orders)
            .SingleOrDefaultAsync(u => u.Id == id);

        return user?.Orders;
    }
}