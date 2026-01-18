namespace ProductManagementSystem.BAL.DTOs.Products
{
    public class ProductDetailDto
    {
        public int ProductId { get; set; }
        public required string ProductName { get; set; } 
        public required string Description { get; set; } 
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public List<string> Categories { get; set; }
    }
}
