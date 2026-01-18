using ProductManagementSystem.BAL.DTOs.Category;

namespace ProductManagementSystem.BAL.DTOs.Products
{
    public class ProductUpsertDto
    {
        public int? ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public List<int> SelectedCategoryIds { get; set; } = new();

        public List<CategoryLookupDto> Categories { get; set; } = new();
    }
}
