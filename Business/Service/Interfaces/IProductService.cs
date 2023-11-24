using Model;

namespace Business.Service.Interfaces;

public interface IProductService
{
    IList<Product> GetProducts();
    Product AddProduct(Product product);
    Product? GetProduct(Guid id);
    void DeleteProduct(Guid id);
}