using Ecommerce.interfaces;
using Ecommerce.Models;
using System.Linq;

namespace Ecommerce.services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Order> addOrder(Order order){
            if(order.OrderDetails.Any())
            {
                double total = 0;
                foreach(var detail in order.OrderDetails)
                {
                    detail.Order = order;

                    if(detail.Product?.price != null)
                    {
                        total += detail.Product.price.Value;
                    }

                    _unitOfWork.OrderDetailRepository.Add(detail);
                }
                
                order.totalPrice = total;
            }
            
            var addedOrder = _unitOfWork.OrderRepository.Add(order);
            await _unitOfWork.CommitAsync();

            return addedOrder;
        }


        public async Task<List<Order>> getAllOrders()
        {
            return await _unitOfWork.OrderRepository.GetAll();
        }

        public async Task<Order?> getOrder(int id)
        {
            return await _unitOfWork.OrderRepository.GetById(id);
        }
    }
}
