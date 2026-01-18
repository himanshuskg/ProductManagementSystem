namespace ProductManagementSystem.BAL.DTOs.Category
{
    public class CategoryListDto
    {
        public int CategoryId { get; set; }
        public required string CategoryName { get; set; }
        public required string Description { get; set; }
    }
}
