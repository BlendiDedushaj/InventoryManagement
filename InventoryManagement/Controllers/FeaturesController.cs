using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Controllers
{
    public class FeaturesController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public FeaturesController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
