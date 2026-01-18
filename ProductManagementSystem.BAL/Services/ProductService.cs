using Microsoft.EntityFrameworkCore;
using ProductManagementSystem.BAL.DTOs.Category;
using ProductManagementSystem.BAL.DTOs.Common;
using ProductManagementSystem.BAL.DTOs.Products;
using ProductManagementSystem.BAL.Interfaces;
using ProductManagementSystem.DAL.Repositories.Implementations;
using ProductManagementSystem.DAL.Repositories.Interfaces;
using ProductManagementSystem.DOMAIN.Product;

namespace ProductManagementSystem.BAL.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductService(IProductRepository productRepository, IProductCategoryRepository productCategoryRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _productCategoryRepository = productCategoryRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<PagedResultDto<ProductListDto>> GetProductsAsync(ProductFilterDto filter)
        {
            var query = _productRepository.GetQueryable();
            if (!string.IsNullOrWhiteSpace(filter.SearchText))
            {
                query = query.Where(p =>EF.Functions.Like(p.ProductName, $"%{filter.SearchText}%"));
            }

            if (filter.MinQuantity.HasValue)
                query = query.Where(p => p.Quantity >= filter.MinQuantity.Value);

            if (filter.MinPrice.HasValue)
                query = query.Where(p => p.Price >= filter.MinPrice.Value);

            if (filter.MaxPrice.HasValue)
                query = query.Where(p => p.Price <= filter.MaxPrice.Value);

            if (filter.CategoryId.HasValue)
                query = query.Where(p =>p.ProductCategories.Any(pc => pc.CategoryId == filter.CategoryId));

            int totalCount = await query.CountAsync();

            var items = await query.OrderBy(p => p.ProductName)
                                   .Skip(filter.Skip)
                                   .Take(filter.PageSize)
                                   .Select(p => new ProductListDto
                                   {
                                       ProductId = p.ProductId,
                                       ProductName = p.ProductName,
                                       Quantity = p.Quantity,
                                       Price = p.Price,
                                       Categories = string.Join(", ",
                                           p.ProductCategories.Select(pc => pc.Category.CategoryName))
                                   }).ToListAsync();

            return new PagedResultDto<ProductListDto>
            {
                Items = items,
                TotalCount = totalCount,
                Page = filter.Page,
                PageSize = filter.PageSize
            };
        }
        public async Task<ProductUpsertDto?> GetUpsertDetailsAsync(int id)
        {
            var product = await _productRepository.GetQueryable()
                .Include(p => p.ProductCategories)
                .FirstOrDefaultAsync(p => p.ProductId == id);

            if (product == null)
                return null;

            var categories = await _categoryRepository.GetQueryable()
                .Select(c => new CategoryLookupDto
                {
                    CategoryId = c.CategoryId,
                    CategoryName = c.CategoryName
                }).ToListAsync();

            return new ProductUpsertDto
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                Description = product.Description,
                Quantity = product.Quantity,
                Price = product.Price,
                SelectedCategoryIds = product.ProductCategories
                    .Select(pc => pc.CategoryId)
                    .ToList(),
                Categories = categories
            };
        }

        public Task<ProductEntity?> GetProductAsync(int productId)
        {
            return _productRepository.GetByIdAsync(productId);
        }

        public async Task AddAsync(ProductUpsertDto dto)
        {
            var product = new ProductEntity
            {
                ProductName = dto.ProductName,
                Description = dto.Description,
                Quantity = dto.Quantity,
                Price = dto.Price
            };

            int productId = await _productRepository.AddProductAsync(product);
            await _productCategoryRepository.ModifyCategoriesAsync(productId, dto.SelectedCategoryIds);
        }

        public async Task UpdateAsync(ProductUpsertDto dto)
        {
            var product = new ProductEntity
            {
                ProductId = dto.ProductId.Value,
                ProductName = dto.ProductName,
                Description = dto.Description,
                Quantity = dto.Quantity,
                Price = dto.Price
            };

            await _productRepository.UpdateProductAsync(product);
            await _productCategoryRepository.ModifyCategoriesAsync(dto.ProductId.Value,dto.SelectedCategoryIds);
        }

        public async Task DeleteAsync(int productId)
        {
            await _productCategoryRepository.ModifyCategoriesAsync(productId,new List<int>());
            await _productRepository.DeleteProductAsync(productId);
        }
    }
}
