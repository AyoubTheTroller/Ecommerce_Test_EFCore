using Ecommerce.Models;

namespace Ecommerce.interfaces{
    public interface IOrderDetailService{
        public Task<OrderDetail> addOrderDetail(OrderDetail category);
        public Task<OrderDetail?> GetOrderDetail(int id);
        public Task<List<OrderDetail>> getAllOrderDetails();
    }
}