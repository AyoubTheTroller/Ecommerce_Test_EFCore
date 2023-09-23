using Ecommerce.interfaces;
using Ecommerce.Models;

namespace Ecommerce.services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Product> addProduct(Product product)
        {
            var addedProduct = _unitOfWork.ProductRepository.Add(product);
            await _unitOfWork.CommitAsync();
            return addedProduct;
        }

        public async Task<List<Product>> getAllProducts()
        {
            return await _unitOfWork.ProductRepository.GetAll();
        }

        public async Task<Product?> getProduct(int id)
        {
            return await _unitOfWork.ProductRepository.GetById(id);
        }
    }
}