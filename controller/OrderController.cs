using System.Security.Claims;
using Ecommerce.Models;
using Ecommerce.interfaces;
using Ecommerce.DTO;
using Ecommerce.Exceptions;

namespace Ecommerce.Controllers
{
    public static class OrderController
    {
        public static void MapOrderRoutes(WebApplication app)
        {
            MapGetAllOrders(app);
            MapGetOrderById(app);
            MapCreateOrder(app);
        }

        private static void MapGetAllOrders(WebApplication app)
        {
            app.MapGet("/orders", (IOrderService orderService) => orderService.getAllOrders());
        }

        private static void MapGetOrderById(WebApplication app)
        {
            app.MapGet("/orders/{id:int}", (int id, IOrderService orderService) =>
            {
                var order = orderService.getOrder(id);
                return Results.Ok(order);
            });
        }

        private static void MapCreateOrder(WebApplication app)
        {
            app.MapPost("/orders/create",CreateOrderHandler);
        }
        private static async Task<IResult> CreateOrderHandler(RequestOrderDTO orderDto, IOrderService orderService, HttpContext context)
        {
            var userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return Results.BadRequest("User ID not found in token.");
            }

            orderDto.UserId = userId;

            var addedOrder = await orderService.addOrder(orderDto);

            var dto = new OrderDTO
            {
                Id = addedOrder.Id,
                UserId = addedOrder.UserId,
                DateTime = addedOrder.DateTime,
                TotalPrice = addedOrder.TotalPrice,
                OrderDetails = addedOrder.OrderDetails.Select(detail => new OrderDetailDTO
                {
                    Id = detail.Id,
                    ProductId = detail.productId
                }).ToList()
            };

            return Results.Ok(dto);
        }

    }
}
