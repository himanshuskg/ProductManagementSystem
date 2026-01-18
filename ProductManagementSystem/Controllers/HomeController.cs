using Microsoft.AspNetCore.Mvc;
using ProductManagementSystem.BAL.DTOs.Home;
using ProductManagementSystem.BAL.Interfaces;
using ProductManagementSystem.Models;
using System.Diagnostics;

namespace ProductManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;

        public HomeController(ILogger<HomeController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var dashboardData = await _productService.GetDashboardAsync();
            return View(dashboardData ?? new DashboardDto());
        }
      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
