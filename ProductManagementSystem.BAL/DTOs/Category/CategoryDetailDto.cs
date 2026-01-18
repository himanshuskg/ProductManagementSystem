namespace ProductManagementSystem.BAL.DTOs.Category
{
    public class CategoryDetailDto
    {
        public int CategoryId { get; set; }
        public required string CategoryName { get; set; } 
        public required string Description { get; set; } 
        public List<string> Products { get; set; } = new();
    }
}
