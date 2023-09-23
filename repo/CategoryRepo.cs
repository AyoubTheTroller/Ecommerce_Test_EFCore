using Ecommerce.interfaces;
using Ecommerce.Models;
using Ecommerce.Data;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Repositories{
    public class CategoryRepo : ICategoryRepo
    {
        private EcommerceDbContext _context;
        public CategoryRepo(EcommerceDbContext context){
            _context = context;
        }
        public Category Add(Category category)
        {
            try{
                _context.Categories.Add(category);
                return category;
            }
            catch(Exception ex){
                throw new ApplicationException($"Error when adding category: {ex.Message}");
            }
        }

        public async Task<Category?> GetById(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Category>> GetAll()
        {
            return await _context.Categories.ToListAsync();
        }
    }
}