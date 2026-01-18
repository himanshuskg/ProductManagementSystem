using ProductManagementSystem.BAL.DTOs.Common;
using ProductManagementSystem.BAL.DTOs.Home;
using ProductManagementSystem.BAL.DTOs.Products;
using ProductManagementSystem.DOMAIN.Product;

namespace ProductManagementSystem.BAL.Interfaces
{
    public interface IProductService
    {
        Task<PagedResultDto<ProductListDto>> GetProductsAsync(ProductFilterDto filter);
        Task<ProductEntity?> GetByIdAsync(int productId);
        Task<ProductDetailDto?> GetProductDetailsAsync(int productId);
        Task<ProductUpsertDto?> GetUpsertDetailsAsync(int id);
        Task AddAsync(ProductUpsertDto product);
        Task UpdateAsync(ProductUpsertDto product);
        Task DeleteAsync(int productId);
        Task<DashboardDto?> GetDashboardAsync();
    }
}
