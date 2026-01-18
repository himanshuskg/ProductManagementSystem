using Microsoft.EntityFrameworkCore;
using ProductManagementSystem.DAL.Data;
using ProductManagementSystem.DAL.Repositories.Interfaces;
using ProductManagementSystem.DOMAIN.Category;

namespace ProductManagementSystem.DAL.Repositories.Implementations
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<CategoryEntity>> GetCategoriesAsync()
        {
            return await _context.Categories.AsNoTracking().ToListAsync();
        }

        public async Task<CategoryEntity?> GetByIdAsync(int categoryId)
        {
            return await _context.Categories.AsNoTracking().FirstOrDefaultAsync(c => c.CategoryId == categoryId);
        }

        public async Task AddCategoryAsync(CategoryEntity category)
        {
            await _context.Database.ExecuteSqlRawAsync("EXEC usp_Category_Insert @p0, @p1",category.CategoryName,category.Description);
        }

        public async Task UpdateCategoryAsync(CategoryEntity category)
        {
            await _context.Database.ExecuteSqlRawAsync("EXEC usp_Category_Update @p0, @p1, @p2", 
                                                        category.CategoryId,category.CategoryName, category.Description);
        }

        public async Task DeleteCategoryAsync(int categoryId)
        {
            await _context.Database.ExecuteSqlRawAsync("EXEC usp_Category_Delete @p0",categoryId);
        }
    }
}
