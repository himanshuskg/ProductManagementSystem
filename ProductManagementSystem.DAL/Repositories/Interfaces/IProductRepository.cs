using ProductManagementSystem.DOMAIN.Product;

namespace ProductManagementSystem.DAL.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<List<ProductEntity>> GetProductsAsync();
        Task<ProductEntity?> GetByIdAsync(int id);
        Task AddProductAsync(ProductEntity product);
        Task UpdateProductAsync(ProductEntity product);
        Task DeleteProductAsync(int productId);
    }
}
