using ProductManagementSystem.DOMAIN.Category;

namespace ProductManagementSystem.BAL.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryEntity>> GetCategoriesAsync();
        Task AddCategoryAsync(CategoryEntity category);
        Task UpdateCategoryAsync(CategoryEntity category);
        Task DeleteCategoryAsync(int categoryId);
    }
}
