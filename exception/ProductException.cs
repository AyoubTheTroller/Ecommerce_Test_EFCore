using Ecommerce.Models;

namespace Ecommerce.Exceptions
{
    public class ProductNotFoundException : Exception{
        public ProductNotFoundException(int id) : base($"Product with id '{id}' not found."){}
    }

    public class ProductsByCategorySlugNotFound : Exception{
        public ProductsByCategorySlugNotFound(string slug) : base($"Products by category slug '{slug}' not found."){}
    }
}
