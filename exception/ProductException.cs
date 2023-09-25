using Ecommerce.Models;

namespace Ecommerce.Exceptions
{
    public class ProductNotFoundException : Exception{
        public ProductNotFoundException(int id) : base($"Product with id '{id}' not found."){}
    }
}