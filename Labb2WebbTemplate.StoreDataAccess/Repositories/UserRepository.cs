using Labb2WebbTemplate.Shared.Enums;
using Labb2WebbTemplate.StoreDataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Labb2WebbTemplate.StoreDataAccess.Repositories;

public class UserRepository(StoreDbContext context) 
    : Repository<UserEntity, int>(context)
{
    public async Task<UserEntity?> GetByEmailAsync(string email)
    {
         return await context.Users.SingleOrDefaultAsync( u => u.Email == email);
    }

    public async Task<bool> EmailIsRegistered(string email)
    {
        return context.Users.Any(u => u.Email == email);
    }
    
    public async Task<IEnumerable<UserEntity>> GetByCityAsync(int cityId)
    {
        var users = context.Users.Where(u => u.Address.City.Id == cityId);

        return users;
    }
    public async Task<IEnumerable<UserEntity>> GetByRegionAsync(int regionId)
    {
        var users = context.Users.Where(u => u.Address.City.Region.Id == regionId);

        return users;
    }
}