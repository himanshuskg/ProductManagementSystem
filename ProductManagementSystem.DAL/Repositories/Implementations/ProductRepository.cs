using Microsoft.EntityFrameworkCore;
using ProductManagementSystem.DAL.Data;
using ProductManagementSystem.DAL.Repositories.Interfaces;
using ProductManagementSystem.DOMAIN.Product;

namespace ProductManagementSystem.DAL.Repositories.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductEntity>> GetProductsAsync()
        {
            return await _context.Products.Include(p => p.ProductCategories)
                                          .ThenInclude(pc => pc.Category)
                                          .AsNoTracking().ToListAsync();
        }

        public async Task<ProductEntity?> GetByIdAsync(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.ProductId == id);
        }

        public async Task AddProductAsync(ProductEntity product)
        {
            await _context.Database.ExecuteSqlRawAsync("EXEC usp_Product_Insert @p0, @p1, @p2, @p3",
                   product.ProductName, product.Description, product.Quantity, product.Price);
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