using ProductManagementSystem.BAL.DTOs.Category;
using ProductManagementSystem.BAL.DTOs.Common;

namespace ProductManagementSystem.BAL.Interfaces
{
    public interface ICategoryService
    {
        Task<PagedResultDto<CategoryListDto>> GetCategoriesAsync(CategoryFilterDto filter);
        Task<CategoryDto> GetByIdAsync(int id);
        Task<List<CategoryLookupDto>> GetLookupAsync();
        Task AddAsync(CategoryDto category);
        Task UpdateAsync(CategoryDto category);
        Task DeleteAsync(int categoryId);
        Task<CategoryDetailDto?> GetCategoryDetailsAsync(int categoryId);
    }
}
