using Microsoft.AspNetCore.Mvc;
using ProductManagementSystem.BAL.DTOs.Category;
using ProductManagementSystem.BAL.Interfaces;

namespace ProductManagementSystem.Controllers
{
    [Route("categories")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index(CategoryFilterDto filter)
        {
            var result = await _categoryService.GetCategoriesAsync(filter);
            return View(result);
        }


        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CategoryDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            await _categoryService.AddAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category == null)
                return NotFound();

            return View(category);
        }

        [HttpPost("edit")]
        public async Task<IActionResult> Edit(CategoryDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            await _categoryService.UpdateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }

}

