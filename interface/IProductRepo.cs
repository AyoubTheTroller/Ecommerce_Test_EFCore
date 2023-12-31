using Ecommerce.Models;

namespace Ecommerce.interfaces{
    public interface IProductRepo{
        public Product Add(Product product);
        public Task<Product?> GetById(int id);
        public Task<List<Product>> GetAll();
        public Task<List<Product>?> GetAllByCategorySlug(string slug); 
        public Task<List<Product>?> GetAllByPriceRange(double min, double max); 
        public IQueryable<Product> AsQueryable();
    }
}