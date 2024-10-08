using System.ComponentModel.DataAnnotations;

namespace BusinessObject
{
    public class ProductDto
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        [StringLength(100)]
        public string ProductName { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Weight must be greater than 0")]
        public decimal Weight { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Unit Price must be greater than 0")]
        public decimal UnitPrice { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Units in Stock must be at least 1")]
        public int UnitsInStock { get; set; }
    }
}
