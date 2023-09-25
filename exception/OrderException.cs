using Ecommerce.Models;

namespace Ecommerce.Exceptions
{
    public class OrderMissingProductException : Exception{
        public OrderMissingProductException(int id) : base($"Product with id '{id}' not found."){}
    }

    public class OrderMissingOrderDetailsException : Exception{
        public OrderMissingOrderDetailsException() : base("Incoming order has missing order details, not placeble"){}
    }
}
