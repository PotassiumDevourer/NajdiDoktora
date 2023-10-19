using Microsoft.AspNetCore.Mvc;
using NajdiDoktoraApp.Models;
using NajdiDoktoraApp.Services;
using System.Diagnostics;
using NajdiDoktoraApp.Enums;

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
            return View();
        }

        public async Task<IActionResult> Search(SearchResults model)
        {
            var items = await _api.GetClinics(new SearchParams()
            {
                ResultCount = 5,
                Type = ClinicType.Dentist,
                UserLat = 50.2044472,
                UserLong = 15.8292865,
            });
            model.Results = items;
            return View(model);
        }

        public async  Task<IActionResult> SearchFor(SearchResults model)
        {
            var items = await _api.GetClinics(new SearchParams()
            {
                ResultCount = 5,
                Type = model.Parameters.Type,
                UserLat = 50.2044472,
                UserLong = 15.8292865,
            });
            model.Results = items;
            return RedirectToAction("Search", model);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Detail()
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