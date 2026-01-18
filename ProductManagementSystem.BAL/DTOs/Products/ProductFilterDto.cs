using ProductManagementSystem.BAL.DTOs.Common;

namespace ProductManagementSystem.BAL.DTOs.Products
{
    public class ProductFilterDto : PaginationDto
    {
        public int? CategoryId { get; set; }
        public int? MinQuantity { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public string? SearchText { get; set; }
    }
}
