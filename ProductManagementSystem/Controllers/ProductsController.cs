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
            {
                var categoryLookups = await _categoryService.GetLookupAsync();
                dto.Categories = categoryLookups;
                return View("Upsert", dto);
            }

            try
            {
                if (dto.ProductId == null || dto.ProductId == 0)
                {
                    await _productService.AddAsync(dto);
                    TempData["Message"] = $"Product <strong>{dto.ProductName}</strong> has been created successfully!";
                }
                else
                {
                    await _productService.UpdateAsync(dto);
                    TempData["Message"] = $"Changes to <strong>{dto.ProductName}</strong> have been saved successfully.";
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = "An error occurred while saving the product. Please try again.";
            }

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
            var product = await _productService.GetByIdAsync(id);
            if (product != null)
            {
                string deletedName = product.ProductName;
                await _productService.DeleteAsync(id);
                TempData["Message"] = $"Success: '{deletedName}' has been removed from the products.";
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var product = await _productService.GetProductDetailsAsync(id);
            if (product == null)
                return NotFound();

            return View(product);
        }

    }
}
