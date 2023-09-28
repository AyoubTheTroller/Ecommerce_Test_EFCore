using Ecommerce.DTO;
using Ecommerce.Models;

namespace Ecommerce.interfaces{
    public interface IOrderService{
        public Task<Order> addOrder(RequestOrderDTO order);
        public Task<Order?> getOrder(int id);
        public Task<List<Order>> getAllOrders();
    }
}