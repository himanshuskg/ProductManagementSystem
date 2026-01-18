using ProductManagementSystem.DOMAIN.Product;

namespace ProductManagementSystem.DAL.Repositories.Interfaces
{
    public interface IProductRepository
    {
        IQueryable<ProductEntity> GetQueryable();
        IQueryable<ProductEntity> AsQueryable();
        Task<ProductEntity?> GetByIdAsync(int id);
        Task<int> AddProductAsync(ProductEntity product);
        Task UpdateProductAsync(ProductEntity product);
        Task DeleteProductAsync(int productId);
    }
}
