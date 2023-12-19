using _Data;
using _Data.Repository;
using Model;

namespace KaffeShopAPIBackendTest.FakeRepositories;

public class FakeProductRepository : IProductRepository
{
    private readonly CoffeeShopContext _context;

    public FakeProductRepository(CoffeeShopContext context)
    {
        _context = context;
    }

    public IList<Product> GetProducts()
    {
        return _context.Products.ToList();
    }

    public Product AddProduct(Product product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();
        return product;
    }

    public Product GetProduct(Guid id)
    {
        return _context.Products.Find(id);
    }

    public void DeleteProduct(Guid id)
    {
        _context.Products.Remove(GetProduct(id));
        _context.SaveChanges();
    }
}