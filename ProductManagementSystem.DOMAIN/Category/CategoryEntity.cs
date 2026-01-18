using ProductManagementSystem.DOMAIN.Junctions;

namespace ProductManagementSystem.DOMAIN.Category
{
    public class CategoryEntity
    {
        public int CategoryId { get; set; }
        public required string CategoryName { get; set; }
        public required string Description { get; set; }
        public ICollection<ProductCategoryEntity> ProductCategories { get; set; }
    }

}
