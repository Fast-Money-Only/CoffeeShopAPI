using _Data;
using _Data.Repository;
using Model;

namespace KaffeShopAPIBackendTest.FakeRepositories;

public class FakeCoffeePlaceRepository : ICoffeePlaceRepository
{
    private readonly CoffeeShopContext _context;

    public FakeCoffeePlaceRepository(CoffeeShopContext context)
    {
        _context = context;   
    }
    public CoffeePlace GetCoffeePlace(Guid id)
    {
        return _context.CoffeePlaces.Find(id);
    }

    public IList<CoffeePlace> GetCoffeePlaceces()
    {
        return _context.CoffeePlaces.ToList();
    }
    
}