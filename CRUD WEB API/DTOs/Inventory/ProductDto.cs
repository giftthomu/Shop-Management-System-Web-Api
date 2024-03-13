using System.ComponentModel.DataAnnotations;

namespace Shop_Management_WEB_API.DTOs.Inventory
{
    public class ProductDto
    {
        public int ProductId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Product name must be between 3 and 50 characters.")]
        public string ProductName { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 10, ErrorMessage = "Product description must be between 10 and 200 characters.")]
        public string ProductDescription { get; set; }

        [Required]
        [Range(0.01, 10000.00, ErrorMessage = "Price must be between 0.01 and 10000.00")]
        public decimal Price { get; set; }

        [Required]
        [Range(1, 1000, ErrorMessage = "Quantity must be between 1 and 1000.")]
        public int Quantity { get; set; }
    }
}
