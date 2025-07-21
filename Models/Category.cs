using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Name { get; set; }
        [Required]
        [MinLength(10)]
        [MaxLength(50)]
        public string Description { get; set; } // New property for category description
        public List<Product>? Products { get; set; } = new List<Product>(); // Navigation property to Products

    }
}
