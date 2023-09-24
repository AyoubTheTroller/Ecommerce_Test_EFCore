using Ecommerce.Models;

namespace Ecommerce.interfaces{
    public interface IOrderService{
        public Task<Order> addOrder(Order order);
        public Task<Order?> getOrder(int id);
        public Task<List<Order>> getAllOrders();
    }
}