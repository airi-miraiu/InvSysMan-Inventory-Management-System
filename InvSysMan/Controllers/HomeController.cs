using System.Diagnostics;
using InvSysMan.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using InvSysMan.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace InvSysMan.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly InventoryManagementContext _context; // Inject the context

        public HomeController(ILogger<HomeController> logger, InventoryManagementContext context) // Modify constructor
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            // Calculate key metrics
            var totalInventoryValue = _context.Products.Sum(p => p.Price * p.ProductQuantity);
            var productsInStock = _context.Products.Count();
            var lowStockItems = _context.Products.Where(p => p.ProductQuantity < 10).Count(); // Example threshold

            // Get recent purchases (adjust as needed, including product details)
            var recentPurchases = _context.Purchase
                .OrderByDescending(p => p.PurchasedDate)
                .Take(5)
                .ToList();

            // Pass data to the view using ViewBag
            ViewBag.TotalInventoryValue = totalInventoryValue;
            ViewBag.ProductsInStock = productsInStock;
            ViewBag.LowStockItems = lowStockItems;
            ViewBag.RecentPurchases = recentPurchases;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}