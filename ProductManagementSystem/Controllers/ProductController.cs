using Microsoft.AspNetCore.Mvc;
using ProductManagementSystem.BAL.DTOs.Products;
using ProductManagementSystem.BAL.Interfaces;
using ProductManagementSystem.DOMAIN.Product;

namespace ProductManagementSystem.Controllers
{
    [Route("products")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetProducts([FromQuery] ProductFilterDto filter)
        {
            var products = await _productService.GetProductsAsync(filter);
            return Json(products);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] ProductEntity product)
        {
            await _productService.AddProductAsync(product);
            return Ok();
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] ProductEntity product)
        {
            await _productService.UpdateProductAsync(product);
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.DeleteProductAsync(id);
            return Ok();
        }
    }
}
