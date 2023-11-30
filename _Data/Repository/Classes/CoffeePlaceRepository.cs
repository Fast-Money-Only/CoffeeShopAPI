using Model;

namespace _Data.Repository;

public class CoffeePlaceRepository : ICoffeePlaceRepository
{
    private readonly CoffeeShopContext _context;

    public CoffeePlaceRepository(CoffeeShopContext context)
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