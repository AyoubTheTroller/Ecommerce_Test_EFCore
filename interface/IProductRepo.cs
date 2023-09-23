using Ecommerce.Models;

namespace Ecommerce.interfaces{
    public interface IProductRepo{
        public Product Add(Product product);
        public Task<Product?> GetById(int id);
        public Task<List<Product>> GetAll();
    }
}