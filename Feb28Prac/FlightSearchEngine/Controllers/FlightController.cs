using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using FlightSearchEngine.Data;
using FlightSearchEngine.Models;

namespace FlightSearchEngine.Controllers
{
    public class FlightController : Controller
    {
        private readonly DatabaseHelper _db;

        public FlightController(DatabaseHelper db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var model = new SearchViewModel
            {
                SourceList = new SelectList(await _db.GetSourcesAsync()),
                DestinationList = new SelectList(await _db.GetDestinationsAsync())
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SearchFlights(SearchViewModel model)
        {
            Console.WriteLine("SearchFlights HIT");

            if (!ModelState.IsValid)
            {
                Console.WriteLine("ModelState INVALID");
                model.SourceList = new SelectList(await _db.GetSourcesAsync());
                model.DestinationList = new SelectList(await _db.GetDestinationsAsync());
                return View("Index", model);
            }

            Console.WriteLine("ModelState VALID");

            var results = await _db.SearchFlightsAsync(model.Source, model.Destination, model.NumberOfPersons);

            Console.WriteLine("Results count: " + results.Count);

            return View("Results", new SearchResultViewModel
            {
                IsFlightOnly = true,
                Flights = results
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SearchFlightsWithHotels(SearchViewModel model)
        {
            Console.WriteLine("SearchFlightsWithHotels HIT");

            if (!ModelState.IsValid)
            {
                Console.WriteLine("ModelState INVALID");
                model.SourceList = new SelectList(await _db.GetSourcesAsync());
                model.DestinationList = new SelectList(await _db.GetDestinationsAsync());
                return View("Index", model);
            }

            Console.WriteLine("ModelState VALID");

            var results = await _db.SearchFlightsWithHotelsAsync(model.Source, model.Destination, model.NumberOfPersons);

            Console.WriteLine("Results count: " + results.Count);

            return View("Results", new SearchResultViewModel
            {
                IsFlightOnly = false,
                FlightHotels = results
            });
        }
    }
}