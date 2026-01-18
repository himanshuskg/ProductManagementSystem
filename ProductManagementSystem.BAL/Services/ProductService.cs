using ProductManagementSystem.BAL.DTOs.Products;
using ProductManagementSystem.BAL.Interfaces;
using ProductManagementSystem.DAL.Repositories.Interfaces;
using ProductManagementSystem.DOMAIN.Product;

namespace ProductManagementSystem.BAL.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductService(IProductRepository productRepository, IProductCategoryRepository productCategoryRepository)
        {
            _productRepository = productRepository;
            _productCategoryRepository = productCategoryRepository;
        }

        public async Task<List<ProductEntity>> GetProductsAsync(ProductFilterDto filter)
        {
            var products = await _productRepository.GetProductsAsync();
            var query = products.AsQueryable();

            if (filter.CategoryId.HasValue)
            {
                query = query.Where(p => p.ProductCategories.Any(pc => pc.CategoryId == filter.CategoryId));
            }

            if (filter.MinQuantity.HasValue)
            {
                query = query.Where(p => p.Quantity >= filter.MinQuantity.Value);
            }

            if (filter.MinPrice.HasValue)
            {
                query = query.Where(p => p.Price >= filter.MinPrice.Value);
            }

            if (filter.MaxPrice.HasValue)
            {
                query = query.Where(p => p.Price <= filter.MaxPrice.Value);
            }

            if (!string.IsNullOrWhiteSpace(filter.SearchText))
            {
                query = query.Where(p =>
                    p.ProductName.Contains(filter.SearchText));
            }

            return query.Skip(filter.Skip)
                        .Take(filter.PageSize)
                        .ToList();
        }

        public Task AddProductAsync(ProductEntity product)
        {
            return _productRepository.AddProductAsync(product);
        }
        public Task UpdateProductAsync(ProductEntity product)
        { 
           return _productRepository.UpdateProductAsync(product);
        }
        public Task DeleteProductAsync(int productId)
        { 
           return _productRepository.DeleteProductAsync(productId);
        }
        public Task AssignCategoryAsync(int productId, int categoryId)
        {
            return _productCategoryRepository.AddProductCategoryAsync(productId, categoryId);
        }
        public Task RemoveCategoryAsync(int productId, int categoryId)
        {
            return _productCategoryRepository.RemoveProductCategoryAsync(productId, categoryId);
        }
    }
}
