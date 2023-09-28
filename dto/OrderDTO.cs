namespace Ecommerce.DTO{
    public class OrderDTO
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public DateTime DateTime { get; set; }
        public double TotalPrice { get; set; }
        public List<OrderDetailDTO> OrderDetails { get; set; } = new List<OrderDetailDTO>();
    }
}