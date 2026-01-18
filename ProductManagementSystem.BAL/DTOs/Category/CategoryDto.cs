using System.ComponentModel.DataAnnotations;

namespace ProductManagementSystem.BAL.DTOs.Category
{
    public class CategoryDto
    {
        public int CategoryId { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Category Name")]
        public required string CategoryName { get; set; }

        [Required]
        [StringLength(500)]
        public required string Description { get; set; }
    }
}
