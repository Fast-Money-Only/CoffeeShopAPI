using Model;

namespace _Data.Repository;

public class ProductRepository : IProductRepository
{
    public IList<Product> GetProducts()
    {
        throw new NotImplementedException();
    }

    public Product AddProduct(Product product)
    {
        throw new NotImplementedException();
    }

    public Product GetProduct(Guid id)
    {
        throw new NotImplementedException();
    }

    public void DeleteProduct(Guid id)
    {
        throw new NotImplementedException();
    }
}