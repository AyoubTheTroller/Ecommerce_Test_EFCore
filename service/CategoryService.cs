using Ecommerce.interfaces;
using Ecommerce.Models;

namespace Ecommerce.services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Category> addCategory(Category category)
        {
            var addedCategory = _unitOfWork.CategoryRepository.Add(category);
            await _unitOfWork.CommitAsync();
            return addedCategory;
        }

        public async Task<List<Category>> getAllCategories()
        {
            return await _unitOfWork.CategoryRepository.GetAll();
        }

        public async Task<Category?> GetCategory(int id)
        {
            return await _unitOfWork.CategoryRepository.GetById(id);
        }
    }
}
