using Microsoft.AspNetCore.Mvc;
using ProductManagementSystem.BAL.DTOs.Category;
using ProductManagementSystem.BAL.Interfaces;
using ProductManagementSystem.BAL.Services;

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
            if (ModelState.IsValid)
            {
                await _categoryService.AddAsync(dto);
                TempData["Message"] = $"Category <strong>{dto.CategoryName}</strong> created successfully!";
                return RedirectToAction(nameof(Index));
            }
            return View(dto);
        }

        [HttpGet("edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category == null)
                return NotFound();

            return View(category);
        }

        [HttpPost("edit/{id?}")] // This allows the ID to be part of the URL
        public async Task<IActionResult> Edit(CategoryDto dto)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.UpdateAsync(dto);
                TempData["Message"] = $"Changes to <strong>{dto.CategoryName}</strong> saved successfully.";
                return RedirectToAction(nameof(Index));
            }
            return View(dto);
        }

        [HttpGet("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category != null)
            {
                string deletedName = category.CategoryName;
                await _categoryService.DeleteAsync(id);
                TempData["Message"] = $"Category <strong>{deletedName}</strong> has been successfully deleted.";
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var category = await _categoryService.GetCategoryDetailsAsync(id);
            if (category == null)
                return NotFound();

            return View(category);
        }

    }

}

