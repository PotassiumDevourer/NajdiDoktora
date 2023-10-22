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

        public IActionResult ProcessLocation(double longt, double latt)
        {
            return RedirectToAction("Search", new SearchResults()
            {
                Parameters = new SearchParams()
                {
                    Type = ClinicType.Dentist,
                    UserLat = latt,
                    UserLong = longt,
                }
            });
        }

        public async Task<IActionResult> Search(SearchResults model)
        {
            if (model.Parameters == null)
            {
                model = new SearchResults();
                model.Parameters = new SearchParams();
                model.Parameters.Type = ClinicType.Dentist;
            }
            var items = await _api.GetClinics(new SearchParams()
            {
                ResultCount = 5,
                Type = model.Parameters.Type,
                UserLat = 50.2044472,
                UserLong = 15.8292865,
            });
            model.Results = items;
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult DetailPreparation(SearchResults model)
        {
            return RedirectToAction("Detail", model.Results.FirstOrDefault(x=>x.PlaceId != null));
        }
        public async Task<IActionResult> Detail(CompleteClinic model)
        {
            model.Reviews = await _api.GetReviews(model.PlaceId);
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}