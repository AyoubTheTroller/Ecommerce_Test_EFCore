using Ecommerce.Models;
using Ecommerce.interfaces;
using Ecommerce.DTO;
using Ecommerce.Exceptions;

namespace Ecommerce.Controllers{
    public static class OrderController{
        public static void MapOrderRoutes(WebApplication app){
            MapGetAllOrders(app);
            MapGetOrderById(app);
            MapCreateOrder(app);
        }

        private static void MapGetAllOrders(WebApplication app){
            app.MapGet("/orders", (IOrderService orderService) => orderService.getAllOrders());
        }

        private static void MapGetOrderById(WebApplication app){
            app.MapGet("/orders/{id:int}", (int id, IOrderService orderService) =>
            {
                var order = orderService.getOrder(id);
                if (order == null)
                {
                    return Results.NotFound($"Order with ID {id} was not found.");
                }
                return Results.Ok(order);
            });
        }

        private static void MapCreateOrder(WebApplication app){
            app.MapPost("/orders/create", (Order order, IOrderService orderService) => CreateOrderHandler(order, orderService));
        }

        private static async Task<IResult> CreateOrderHandler(Order order, IOrderService orderService){
            if (order == null)
            {
                throw new ArgumentNullException("Invalid order data.");
            }

            var addedOrder = await orderService.addOrder(order);

            var orderDTO = new OrderDTO
            {
                Id = addedOrder.Id,
                UserId = addedOrder.userId,
                DateTime = addedOrder.dateTime,
                TotalPrice = addedOrder.totalPrice,
                OrderDetails = addedOrder.OrderDetails.Select(detail => new OrderDetailDTO 
                {
                    Id = detail.Id,
                    ProductId = detail.productId
                }).ToList()
            };

            return Results.Ok(orderDTO);
        }

    }
}
