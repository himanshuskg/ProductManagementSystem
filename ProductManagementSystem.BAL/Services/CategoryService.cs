using Microsoft.EntityFrameworkCore;
using ProductManagementSystem.BAL.DTOs.Category;
using ProductManagementSystem.BAL.DTOs.Common;
using ProductManagementSystem.BAL.Interfaces;
using ProductManagementSystem.DAL.Repositories.Implementations;
using ProductManagementSystem.DAL.Repositories.Interfaces;
using ProductManagementSystem.DOMAIN.Category;

namespace ProductManagementSystem.BAL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<PagedResultDto<CategoryListDto>> GetCategoriesAsync(CategoryFilterDto filter)
        {
            var query = _categoryRepository.GetQueryable();

            if (!string.IsNullOrWhiteSpace(filter.SearchText))
            {
                query = query.Where(c =>EF.Functions.Like(c.CategoryName, $"%{filter.SearchText}%"));
            }

            int totalCount = await query.CountAsync();

            var items = await query
                .OrderBy(c => c.CategoryName)
                .Skip(filter.Skip)
                .Take(filter.PageSize)
                .Select(c => new CategoryListDto
                {
                    CategoryId = c.CategoryId,
                    CategoryName = c.CategoryName,
                    Description = c.Description
                })
                .ToListAsync();

            return new PagedResultDto<CategoryListDto>
            {
                Items = items,
                TotalCount = totalCount,
                Page = filter.Page,
                PageSize = filter.PageSize
            };
        }

        public Task AddAsync(CategoryDto category)
        {
            var entity = new CategoryEntity
            {
                CategoryName = category.CategoryName,
                Description = category.Description
            };
            return _categoryRepository.AddAsync(entity);
        }
        public async Task<CategoryDto> GetByIdAsync(int id)
        {
            var entity = await _categoryRepository.GetByIdAsync(id);
            var dto = new CategoryDto
            {
                CategoryId =entity.CategoryId,
                CategoryName = entity.CategoryName,
                Description = entity.Description
            };
            return dto;
        }
        public async Task<List<CategoryLookupDto>> GetLookupAsync()
        {
            var categories = await _categoryRepository.GetQueryable()
                             .Select(c => new CategoryLookupDto
                             {
                                 CategoryId = c.CategoryId,
                                 CategoryName = c.CategoryName
                             }).ToListAsync();
            return categories;
        }
        public Task UpdateAsync(CategoryDto category)
        {
            var entity = new CategoryEntity
            {
                CategoryId =category.CategoryId,
                CategoryName = category.CategoryName,
                Description = category.Description
            };
            return _categoryRepository.UpdateAsync(entity);
        }
        public Task DeleteAsync(int categoryId)
        {
            return _categoryRepository.DeleteAsync(categoryId);
        }
    }
}
