using _Data;
using _Data.Repository;
using Model;

namespace KaffeShopAPIBackendTest.FakeRepositories;

public class FakeCakeRepository : ICakeRepository
{
    private readonly CoffeeShopContext _context;

    public FakeCakeRepository(CoffeeShopContext context)
    {
        _context = context;
    }

    public IList<Cake> GetCakes()
    {
        return _context.Cakes.ToList();
    }

    public Cake GetCake(Guid id)
    {
        return _context.Cakes.Find(id);
    }

    public Cake CreateCake(Cake cake)
    {
        _context.Cakes.Add(cake);
        _context.SaveChanges();
        return cake;
    }

    public void DeleteCake(Guid id)
    {
        _context.Cakes.Remove(GetCake(id));
        _context.SaveChanges();
    }
}