using ProductManagementSystem.BAL.DTOs.Category;
using System.ComponentModel.DataAnnotations;

namespace ProductManagementSystem.BAL.DTOs.Products
{
    public class ProductUpsertDto
    {
        public int? ProductId { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name ="Product Name")]
        public string ProductName { get; set; } = null!;

        [Required]
        [StringLength(500)]
        public string Description { get; set; } = null!;

        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0")]
        public int Quantity { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }

        //[Required(ErrorMessage = "At least one category is required")]
        public List<int> SelectedCategoryIds { get; set; } = new();

        public List<CategoryLookupDto> Categories { get; set; } = new();
    }
}
