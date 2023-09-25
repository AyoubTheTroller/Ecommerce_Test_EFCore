using Ecommerce.Models;
namespace Ecommerce.interfaces{
    public interface IProductService{
        public Task<Product> addProduct(Product product);
        public Task<Product?> getProduct(int id);
        public Task<List<Product>> getAllProducts();
        public Task<List<Product>?> getAllProductsByCategorySlug(string slug);
        public Task<List<Product>?> getAllProductsByPriceRange(double min, double max); 
    }
}