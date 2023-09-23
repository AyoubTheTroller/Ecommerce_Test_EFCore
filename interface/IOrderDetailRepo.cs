using Ecommerce.Models;

namespace Ecommerce.interfaces{
    public interface IOrderDetailRepo{
        public OrderDetail Add(OrderDetail orderDetail);
        public Task<OrderDetail?> GetById(int id);
        public Task<List<OrderDetail>> GetAll();
    }
}