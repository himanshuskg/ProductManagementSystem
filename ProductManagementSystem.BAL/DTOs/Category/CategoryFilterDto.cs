using ProductManagementSystem.BAL.DTOs.Common;

namespace ProductManagementSystem.BAL.DTOs.Category
{
    public class CategoryFilterDto:PaginationDto
    {
        public string? SearchText { get; set; }
    }
}
