using Ecommerce.Models;
namespace Ecommerce.interfaces{
    public interface IProductService{
        public Task<Product> addProduct(Product product);
        public Task<Product?> getProduct(int id);
        public Task<List<Product>> getAllProducts();
    }
}