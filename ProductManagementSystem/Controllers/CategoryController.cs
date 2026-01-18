using Microsoft.AspNetCore.Mvc;
using ProductManagementSystem.BAL.Interfaces;
using ProductManagementSystem.DOMAIN.Category;

namespace ProductManagementSystem.Controllers
{
    [Route("categories")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet("list")]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _categoryService.GetCategoriesAsync();
            return Json(categories);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CategoryEntity category)
        {
            await _categoryService.AddCategoryAsync(category);
            return Ok();
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] CategoryEntity category)
        {
            await _categoryService.UpdateCategoryAsync(category);
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return Ok();
        }
    }
}
