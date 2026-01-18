using ProductManagementSystem.DOMAIN.Category;
using ProductManagementSystem.DOMAIN.Product;

namespace ProductManagementSystem.DOMAIN.Junctions
{
    public class ProductCategoryEntity
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }

        public ProductEntity Product { get; set; }
        public CategoryEntity Category { get; set; }
    }
}
