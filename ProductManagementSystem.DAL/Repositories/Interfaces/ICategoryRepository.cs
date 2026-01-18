using ProductManagementSystem.DOMAIN.Category;

namespace ProductManagementSystem.DAL.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<CategoryEntity>> GetCategoriesAsync();
        Task<CategoryEntity?> GetByIdAsync(int categoryId);
        Task AddCategoryAsync(CategoryEntity category);
        Task UpdateCategoryAsync(CategoryEntity category);
        Task DeleteCategoryAsync(int categoryId);
    }
}
