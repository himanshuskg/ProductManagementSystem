using ProductManagementSystem.DOMAIN.Junctions;

namespace ProductManagementSystem.DOMAIN.Product
{
    public class ProductEntity
    {
        public int ProductId { get; set; }
        public required string ProductName { get; set; }
        public required string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public ICollection<ProductCategoryEntity> ProductCategories { get; set; }
    }
}

