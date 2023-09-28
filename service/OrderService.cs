using Ecommerce.DTO;
using Ecommerce.interfaces;
using Ecommerce.Models;
using Ecommerce.Exceptions;

namespace Ecommerce.services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Order> addOrder(RequestOrderDTO orderDto)
        {
            double total = 0;
            
            var newOrder = new Order
            {
                UserId = orderDto.UserId,
                DateTime = orderDto.DateTime
            };

            if (orderDto.OrderDetails.Any())
            {
                foreach (var detailDto in orderDto.OrderDetails)
                {
                    var product = await _unitOfWork.ProductRepository.GetById(detailDto.ProductId);
                    if (product == null)
                    {
                        throw new OrderMissingProductException(detailDto.ProductId);
                    }

                    total += product.price;

                    var orderDetail = new OrderDetail
                    {
                        productId = detailDto.ProductId,
                        Order = newOrder
                    };

                    newOrder.OrderDetails.Add(orderDetail);

                    _unitOfWork.OrderDetailRepository.Add(orderDetail);
                }
            }
            else
            {
                throw new OrderMissingOrderDetailsException();
            }
            
            newOrder.TotalPrice = total;

            _unitOfWork.OrderRepository.Add(newOrder);
            await _unitOfWork.CommitAsync();

            return newOrder;
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
