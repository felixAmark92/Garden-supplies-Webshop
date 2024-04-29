using System.Reflection;
using Labb2WebbTemplate.StoreDataAccess.Entities;
using Labb2WebbTemplate.StoreDataAccess.Entities.Address;
using Microsoft.EntityFrameworkCore;

namespace Labb2WebbTemplate.StoreDataAccess;

public class StoreDbContext : DbContext
{
    public DbSet<OrderEntity> Orders { get; set; }
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<CategoryEntity> Categories { get; set; }
    public DbSet<AddressEntity> Addresses { get; set; }
    public DbSet<RegionEntity> Regions { get; set; }
    public DbSet<CityEntity> Cities { get; set; }
    
    public StoreDbContext(DbContextOptions options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
    
}