using Model;

namespace _Data.Repository;

public interface IProductRepository
{
    IList<Product> GetProducts();
    Product AddProduct(Product product);
    Product GetProduct(Guid id);
    void DeleteProduct(Guid id);
}