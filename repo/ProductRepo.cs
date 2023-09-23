using Ecommerce.interfaces;
using Ecommerce.Models;
using Ecommerce.Data;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Repositories{
    public class ProductRepo : IProductRepo
    {
        private EcommerceDbContext _context;
        public ProductRepo(EcommerceDbContext context){
            _context = context;
        }
        public Product Add(Product product)
        {
            try{
                _context.Products.Add(product);
                return product;
            }
            catch(Exception ex){
                throw new ApplicationException($"Error when adding product: {ex.Message}");
            }
        }

        public async Task<Product?> GetById(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }
    }
}