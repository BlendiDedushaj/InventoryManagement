﻿using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Controllers
{
    public class FeaturesController : Controller
    {
        private readonly ILogger<FeaturesController> _logger;

        public FeaturesController(ILogger<FeaturesController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
