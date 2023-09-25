namespace Ecommerce.Models{
    public class Category{
        public int Id {get;set;}
        public string? name {get;set;}
        public string? description {get;set;}
        public string? Slug { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}