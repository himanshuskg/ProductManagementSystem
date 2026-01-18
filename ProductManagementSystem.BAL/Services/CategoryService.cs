using ProductManagementSystem.BAL.Interfaces;
using ProductManagementSystem.DAL.Repositories.Interfaces;
using ProductManagementSystem.DOMAIN.Category;

namespace ProductManagementSystem.BAL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepo;

        public CategoryService(ICategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }
        public Task<List<CategoryEntity>> GetCategoriesAsync()
        {
            return _categoryRepo.GetCategoriesAsync();
        }
        public Task AddCategoryAsync(CategoryEntity category)
        {
            return _categoryRepo.AddCategoryAsync(category);
        }
        public Task UpdateCategoryAsync(CategoryEntity category)
        {
            return _categoryRepo.UpdateCategoryAsync(category);
        }
        public Task DeleteCategoryAsync(int categoryId)
        {
            return _categoryRepo.DeleteCategoryAsync(categoryId);
        }
    }
}
