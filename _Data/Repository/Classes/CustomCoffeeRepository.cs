using Model;

namespace _Data.Repository;

public class CustomCoffeeRepository : ICustomCoffeeRepository
{
    private readonly CoffeeShopContext _context;
    
    public CustomCoffeeRepository(CoffeeShopContext context)
    {
        _context = context;
    }
    
    public CustomCoffee CreateCustomCoffee(CustomCoffee customCoffee)
    {
        _context.CustomCoffees.Add(customCoffee);
        _context.SaveChanges();
        return customCoffee;
    }

    public CustomCoffee? GetCustomCoffee(Guid id)
    {
        return _context.CustomCoffees.Find(id);
    }
}