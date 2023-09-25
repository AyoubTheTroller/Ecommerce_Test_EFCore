using Ecommerce.interfaces;
using Ecommerce.Models;
using Ecommerce.Data;
using Microsoft.EntityFrameworkCore;
using Ecommerce.Exceptions;

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
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);;
            if(product != null) return product;
            else throw new ProductNotFoundException(id);
        }

        public async Task<List<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }
    }
}