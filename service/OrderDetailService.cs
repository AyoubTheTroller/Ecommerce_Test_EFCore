using Ecommerce.interfaces;
using Ecommerce.Models;

namespace Ecommerce.services
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderDetailService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OrderDetail> addOrderDetail(OrderDetail orderDetail)
        {
            var addedOrderDetail = _unitOfWork.OrderDetailRepository.Add(orderDetail);
            await _unitOfWork.CommitAsync();
            return addedOrderDetail;
        }

        public async Task<List<OrderDetail>> getAllOrderDetails()
        {
            return await _unitOfWork.OrderDetailRepository.GetAll();
        }

        public async Task<OrderDetail?> GetOrderDetail(int id)
        {
            return await _unitOfWork.OrderDetailRepository.GetById(id);
        }
    }
}
