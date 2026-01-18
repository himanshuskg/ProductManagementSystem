using ProductManagementSystem.BAL.DTOs.Products;
using ProductManagementSystem.DOMAIN.Product;

namespace ProductManagementSystem.BAL.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductEntity>> GetProductsAsync(ProductFilterDto filter);
        Task AddProductAsync(ProductEntity product);
        Task UpdateProductAsync(ProductEntity product);
        Task DeleteProductAsync(int productId);
        Task AssignCategoryAsync(int productId, int categoryId);
        Task RemoveCategoryAsync(int productId, int categoryId);
    }
}
