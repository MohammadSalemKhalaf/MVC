namespace WebApplication1.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int? CategoryId { get; set; } //(nullable) foreign key to Category
        public Category Category { get; set; } // Navigation property to Category
        public string Description { get; set; } // New property for product description
    }
}
