using Ecommerce.Models;

namespace Ecommerce.interfaces{
    public interface ICategoryService{
        public Task<Category> addCategory(Category category);
        public Task<Category?> GetCategory(int id);
        public Task<List<Category>> getAllCategories();
    }
}