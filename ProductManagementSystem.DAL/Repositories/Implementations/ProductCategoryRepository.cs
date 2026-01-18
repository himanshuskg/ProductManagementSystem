using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProductManagementSystem.DAL.Data;
using ProductManagementSystem.DAL.Repositories.Interfaces;
using System.Data;

namespace ProductManagementSystem.DAL.Repositories.Implementations
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly AppDbContext _context;

        public ProductCategoryRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task ModifyCategoriesAsync(int productId, List<int> categoryIds)
        {
            var table = new DataTable();
            table.Columns.Add("Id", typeof(int));

            var productIdParam = new SqlParameter("@ProductId", productId);

            var categoryIdsParam = new SqlParameter("@CategoryIds", table)
            {
                SqlDbType = SqlDbType.Structured,
                TypeName = "dbo.IntIdList"
            };

            await _context.Database.ExecuteSqlRawAsync(
                "EXEC usp_Product_SyncCategories @ProductId, @CategoryIds",
                productIdParam,
                categoryIdsParam
            );
        }
    }

}
