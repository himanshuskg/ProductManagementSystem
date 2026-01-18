using Microsoft.AspNetCore.Mvc;
using ProductManagementSystem.BAL.DTOs.Common;
using ProductManagementSystem.BAL.DTOs.Products;
using ProductManagementSystem.BAL.Interfaces;
using ProductManagementSystem.BAL.Services;

namespace ProductManagementSystem.Controllers
{
    [Route("products")]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductsController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index(ProductFilterDto filter)
        {
            var result = await _productService.GetProductsAsync(filter);
            return View(result);
        }
        [HttpGet("create")]
        public async Task<IActionResult> Create()
        {
            var dto = new ProductUpsertDto
            {
                Categories = await _categoryService.GetLookupAsync()
            };
            return View("Upsert", dto);
        }

        [HttpPost("save")]
        public async Task<IActionResult> Save(ProductUpsertDto dto)
        {
            if (!ModelState.IsValid)
                return View("Upsert", dto);

            if (dto.ProductId == null)
                await _productService.AddAsync(dto);
            else
                await _productService.UpdateAsync(dto);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var dto = await _productService.GetUpsertDetailsAsync(id);
            if (dto == null)
                return NotFound();

            return View("Upsert", dto);
        }

        [HttpGet("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
