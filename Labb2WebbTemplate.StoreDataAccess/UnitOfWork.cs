using Labb2WebbTemplate.StoreDataAccess.Repositories;

namespace Labb2WebbTemplate.StoreDataAccess;

public class UnitOfWork : IDisposable
{
    
    private readonly StoreDbContext _context;
    public CategoryRepository Categories { get; }
    public CityRepository Cities { get; }
    public OrderRepository Orders { get; set; }
    public ProductRepository Products { get; }
    public RegionRepository Regions { get; }
    public UserRepository Users { get; }

    public UnitOfWork(StoreDbContext context)
    {
        _context = context;
        Categories = new CategoryRepository(context);
        Cities = new CityRepository(context);
        Orders = new OrderRepository(context);
        Products = new ProductRepository(context);
        Regions = new RegionRepository(context);
        Users = new UserRepository(context);

    }

    public void SaveChanges()
    {
        var test = _context.SaveChanges();

        Console.WriteLine(test);
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}