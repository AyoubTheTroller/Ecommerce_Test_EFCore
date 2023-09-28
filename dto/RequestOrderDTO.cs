namespace Ecommerce.DTO
{
    public class RequestOrderDTO
    {
        public string UserId { get; set; }
        public DateTime DateTime { get; set; }
        public double TotalPrice { get; set; }
        public ICollection<OrderDetailCreateDTO> OrderDetails { get; set; } = new List<OrderDetailCreateDTO>();
    }
}

