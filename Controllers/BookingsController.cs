using Microsoft.AspNetCore.Mvc;
using TrainBookingSystem.Models;

namespace TrainBookingSystem.Controllers
{
    public class BookingsController : Controller
    {
        // Simulate a database for demonstration purposes
        private static List<Booking> bookings = new List<Booking>();

        // GET: /Bookings/Create/{trainId}
        public IActionResult Create(int trainId)
        {
            // Hardcoded train data for demonstration
            var train = new Train
            {   
                TrainId = trainId,
                Name = "Express Line",
                DepartureCity = "City A",
                ArrivalCity = "City B",
                DepartureTime = DateTime.Today.AddDays(1).AddHours(9),
                ArrivalTime = DateTime.Today.AddDays(1).AddHours(12),
                SeatsAvailable = 50,
                Price = 1500
            };

            return View(train); // Pass train info to view for seat selection
        }

        // POST: /Bookings/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(int trainId, int selectedSeats)
        {
            if (selectedSeats <= 0)
            {
                ModelState.AddModelError("", "Please select at least one seat.");
                return View();
            }

            // In real app, get user ID from authentication
            var userId = 1; // hardcoded for demonstration

            var booking = new Booking
            {
                BookingId = bookings.Count + 1,
                TrainId = trainId,
                UserId = userId,
                Seats = selectedSeats,
                BookingDate = DateTime.Now
            };

            bookings.Add(booking);

            TempData["BookingConfirmation"] = $"Booking successful! Booking ID: {booking.BookingId}";

            return RedirectToAction("MyBookings");
        }

        // GET: /Bookings/MyBookings
        public IActionResult MyBookings()
        {
            // In real app, filter bookings by logged-in user
            var userId = 1; // hardcoded for demonstration
            var userBookings = bookings.Where(b => b.UserId == userId).ToList();

            return View(userBookings);
        }

        // POST: /Bookings/Cancel/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cancel(int id)
        {
            var booking = bookings.FirstOrDefault(b => b.BookingId == id);
            if (booking != null)
            {
                bookings.Remove(booking);
                TempData["CancelMessage"] = "Booking canceled successfully.";
            }
            else
            {
                TempData["CancelMessage"] = "Booking not found.";
            }

            return RedirectToAction("MyBookings");
        }
    }
}

