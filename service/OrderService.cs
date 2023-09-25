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

        public async Task<Order> addOrder(Order order){
            Order? newOrder;
            if(order.OrderDetails.Any())
            {
                double total = 0;
                foreach(var detail in order.OrderDetails)
                {
                    detail.Order = order;

                    if(detail.Product?.price != null)
                    {
                        total += detail.Product.price;
                    }
                    else{
                        try{
                            var product = await _unitOfWork.ProductRepository.GetById(detail.productId); // Forse sarebbe meglio avere un metodo nella repo per ritornare tutti i prodotti in base a una lista di id per fare meno viaggi a db
                            if(product != null){
                                detail.Product = product;
                                total += product.price;
                            }
                        }catch (ProductNotFoundException){
                            throw new OrderMissingProductException(detail.productId);
                        }
                    }
                    _unitOfWork.OrderDetailRepository.Add(detail);
                }
                order.totalPrice = total;
                newOrder = _unitOfWork.OrderRepository.Add(order);
                await _unitOfWork.CommitAsync();
            }
            else{
                throw new OrderMissingOrderDetailsException();
            }
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
