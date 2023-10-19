using Microsoft.AspNetCore.Mvc;
using NajdiDoktoraApp.Models;
using NajdiDoktoraApp.Services;
using System.Diagnostics;

namespace NajdiDoktoraApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApiService _api;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _api = new ApiService(@"AIzaSyCQc83GzJ7_-CgWmE6qlrzb8_so_rnQ0rs");
        }

        public async Task<IActionResult> Index()
        {
            var items = await _api.GetClinics(new SearchParams()
            {
                ResultCount = 15,
                Type = Enums.ClinicType.Dentist,
                UserLat = 50.2044472,
                UserLong = 15.8292865,
            });
            return View();
        }

        public IActionResult Search()
        {
            return View();
        }

        public IActionResult SearchFor()
        {
            return RedirectToAction("Search");
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