 using Microsoft.EntityFrameworkCore;
 using ProductManagementSystem.DAL.Data;
 using ProductManagementSystem.DAL.Repositories.Interfaces;

namespace ProductManagementSystem.DAL.Repositories.Implementations
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly AppDbContext _context;

        public ProductCategoryRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddProductCategoryAsync(int productId, int categoryId)
        {
            await _context.Database.ExecuteSqlRawAsync("EXEC usp_ProductCategory_Insert @p0, @p1",productId, categoryId);
        }

        public async Task RemoveProductCategoryAsync(int productId, int categoryId)
        {
            await _context.Database.ExecuteSqlRawAsync("EXEC usp_ProductCategory_Delete @p0, @p1",productId, categoryId);
        }
    }

}
