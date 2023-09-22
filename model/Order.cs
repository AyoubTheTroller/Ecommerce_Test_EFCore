namespace Ecommerce.Models{
    public class Order{
        public int Id {get; set;}
        public int userId {get; set;}
        public User? user {get; set;}
        public DateTime dateTime {get; set;}
        public double totalPrice {get; set;}
        public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}