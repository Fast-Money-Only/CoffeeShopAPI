using Business.Service.Interfaces;
using Model;

namespace _Data.Repository;

public class ProductService : IProductService
{
    private IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public IList<Product> GetProducts()
    {
        return _productRepository.GetProducts();
    }

    public Product AddProduct(Product product)
    {
        return _productRepository.AddProduct(product);
    }

    public Product GetProduct(Guid id)
    {
        return _productRepository.GetProduct(id);
    }

    public void DeleteProduct(Guid id)
    {
        _productRepository.DeleteProduct(id);
    }
}