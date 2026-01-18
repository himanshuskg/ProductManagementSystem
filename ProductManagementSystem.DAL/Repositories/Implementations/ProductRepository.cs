using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProductManagementSystem.DAL.Data;
using ProductManagementSystem.DAL.Repositories.Interfaces;
using ProductManagementSystem.DOMAIN.Product;
using System.Data;

namespace ProductManagementSystem.DAL.Repositories.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<ProductEntity> GetQueryable()
        {
            return _context.Products.Include(p => p.ProductCategories)
                                    .ThenInclude(pc => pc.Category).AsNoTracking();
        }

        public async Task<ProductEntity?> GetByIdAsync(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.ProductId == id);
        }

        public async Task<int> AddProductAsync(ProductEntity product)
        {
            var productIdParam = new SqlParameter("@ProductId", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };

            await _context.Database.ExecuteSqlRawAsync(
                "EXEC usp_Product_Insert @ProductName, @Description, @Quantity, @Price, @ProductId OUTPUT",
                new SqlParameter("@ProductName", product.ProductName),
                new SqlParameter("@Description", product.Description),
                new SqlParameter("@Quantity", product.Quantity),
                new SqlParameter("@Price", product.Price),
                productIdParam
            );

            return (int)productIdParam.Value;
        }

        public async Task UpdateProductAsync(ProductEntity product)
        {
            await _context.Database.ExecuteSqlRawAsync("EXEC usp_Product_Update @p0, @p1, @p2, @p3, @p4",
                   product.ProductId, product.ProductName, product.Description, product.Quantity, product.Price);
        }

        public async Task DeleteProductAsync(int productId)
        {
            await _context.Database.ExecuteSqlRawAsync("EXEC usp_Product_Delete @p0", productId);
        }
    }
}