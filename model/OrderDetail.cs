namespace Ecommerce.Models
{    
    public class OrderDetail{
        public int Id { get; set; }
        public int orderId { get; set; }
        public Order? Order { get; set; }
        public int productId { get; set; }
        public Product? Product { get; set; }
        public OrderDetail(){}
    }
}
