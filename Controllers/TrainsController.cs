using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using TrainBookingSystem.Models;

namespace TrainBookingSystem.Controllers
{
    public class TrainsController : Controller  
    {
        // Hardcoded sample train data
        private static List<Train> trains = new List<Train>
        {
            new Train { TrainId = 1, Name = "Express 101", DepartureCity = "Karachi", ArrivalCity = "Lahore", DepartureTime = "08:00 AM", ArrivalTime = "08:00 PM", SeatsAvailable = 100, Price = 1500 },
            new Train { TrainId = 2, Name = "Express 202", DepartureCity = "Karachi", ArrivalCity = "Islamabad", DepartureTime = "09:00 AM", ArrivalTime = "09:00 PM", SeatsAvailable = 50, Price = 2000 },
            new Train { TrainId = 3, Name = "Rapid 303", DepartureCity = "Lahore", ArrivalCity = "Islamabad", DepartureTime = "07:00 AM", ArrivalTime = "02:00 PM", SeatsAvailable = 75, Price = 1200 },
        };

        // GET: Trains/Search
        public IActionResult Search(string departureCity, string arrivalCity, string travelDate, string travelClass)
        {
            ViewBag.DepartureCity = departureCity;
            ViewBag.ArrivalCity = arrivalCity;
            ViewBag.TravelDate = travelDate;
            ViewBag.TravelClass = travelClass;

            // Filter results based on user input
            var results = trains.AsEnumerable();
            if (!string.IsNullOrEmpty(departureCity))
                results = results.Where(t => t.DepartureCity.ToLower().Contains(departureCity.ToLower()));
            if (!string.IsNullOrEmpty(arrivalCity))
                results = results.Where(t => t.ArrivalCity.ToLower().Contains(arrivalCity.ToLower()));

            return View(results.ToList());
        }

        // GET: Trains/Details/5
        public IActionResult Details(int id)
        {
            var train = trains.FirstOrDefault(t => t.TrainId == id);
            if (train == null)
            {
                return RedirectToAction("Search");
            }

            return View(train);
        }
    }
}
