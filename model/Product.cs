namespace Ecommerce.Models{
    public class Product{
        public int Id {get; set;}
        public string? name {get; set;}
        public double price {get;set;}
        public Category? Category {get;set;}
        public int? categoryId {get;set;}
        public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    }
}