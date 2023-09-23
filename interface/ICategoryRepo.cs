using Ecommerce.Models;

namespace Ecommerce.interfaces{
    public interface ICategoryRepo{
        public Category Add(Category category);
        public Task<Category?> GetById(int id);
        public Task<List<Category>> GetAll();
    }
}