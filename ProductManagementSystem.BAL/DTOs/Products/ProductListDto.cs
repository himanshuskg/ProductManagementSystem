namespace ProductManagementSystem.BAL.DTOs.Products
{
    public class ProductListDto
    {
        public int ProductId { get; set; }
        public required string ProductName { get; set; } 
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string? Categories { get; set; }
    }
}
