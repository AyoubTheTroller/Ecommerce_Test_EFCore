using Ecommerce.Models;

namespace Ecommerce.interfaces{
    public interface IOrderRepo{
        public Order Add(Order order);
        public Task<Order?> GetById(int id);
        public Task<List<Order>> GetAll();
    }
}