using ProductManagementSystem.DOMAIN.Category;

namespace ProductManagementSystem.DAL.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        IQueryable<CategoryEntity> GetQueryable();
        IQueryable<CategoryEntity> AsQueryable();
        Task<CategoryEntity?> GetByIdAsync(int categoryId);
        Task AddAsync(CategoryEntity category);
        Task UpdateAsync(CategoryEntity category);
        Task DeleteAsync(int categoryId);
    }
}
