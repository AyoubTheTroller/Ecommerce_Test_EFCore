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
        public IQueryable<Product> AsQueryable()
        {
            return _context.Products.AsQueryable();
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

        public async Task<List<Product>?> GetAllByCategorySlug(string slug){
            var products = await _context.Products.Where(p => p.Category != null && p.Category.Slug == slug).ToListAsync();
            if (!products.Any()) throw new ProductsByCategorySlugNotFound(slug);
            return products;
        }

        public async Task<List<Product>?> GetAllByPriceRange(double min, double max){
            var products = await _context.Products.Where(p => p.price >= min && p.price <= max).ToListAsync();
            if (!products.Any()) throw new ProductsByPriceRangeNotFound(min,max);
            return products;
        }
    }
}