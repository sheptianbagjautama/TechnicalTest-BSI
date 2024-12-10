using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TechnicalTest_BSI_Soal3.Models;

namespace TechnicalTest_BSI_Soal3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}