using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class BookingController : Controller
    {

        public ActionResult Flight()
        {
            ViewBag.Provinces = new SelectList(new[]
            {
                "Alberta", "British Columbia", "Manitoba", "New Brunswick",
                "Newfoundland and Labrador", "Nova Scotia", "Ontario", "Prince Edward Island",
                "Quebec", "Saskatchewan"
            });
            return View();
        }

        [HttpPost]
        public ActionResult BookFlight(FlightBookingModel model)
        {
            return RedirectToAction("BookingConfirmation", "Home", model);
        }


        public class FlightBookingModel
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Destination { get; set; }
            public DateTime DepartureDate { get; set; }
            public DateTime ArrivalDate { get; set; }
        }

        public ActionResult CarRental()
        {
            ViewBag.CarModels = new SelectList(new[]
            {
                "BMW", "Tesla Model X", "Toyota", "Honda Civic", "Honda Accord", "Ford F150", "Bentley",
                "Nissan Altima", "Hyundai", "Acura","Kia", "Subaru",
                "Volkswagen", "Mazda"
            });
            return View();
        }

        [HttpPost]
        public ActionResult RentCar(CarRentalModel model)
        {
            return RedirectToAction("CarRentalConfirmation", "Booking", model);
        }

        public ActionResult CarRentalConfirmation(CarRentalModel model)
        {
            return View(model);
        }

        public ActionResult Hotel()
        {
            ViewBag.Provinces = new SelectList(new[]
            {
        "Alberta", "British Columbia", "Manitoba", "New Brunswick",
        "Newfoundland and Labrador", "Nova Scotia", "Ontario", "Prince Edward Island",
        "Quebec", "Saskatchewan"
    });

            ViewBag.Hotels = new SelectList(new[]
            {
        "Confort Inn", "Best Western", "Marriott", "Hilton"
    });

            ViewBag.Guests = new SelectList(new[]
            {
        "1", "2", "3", "4"
    });

            return View("Hotel"); // Pass the model and ViewBag data to the view
        }



        [HttpPost]
        public ActionResult BookHotel(HotelBookingModel model)
        {
            if (ModelState.IsValid)
            {
                // Here you would typically handle the submission (e.g., save to database, send email) and then redirect to the confirmation page
                return RedirectToAction("HotelConfirmation", "Booking", model);
            }

            // If model state is not valid, return to the hotel booking page with validation errors
            return View("Hotel", model);
        }

        public ActionResult HotelConfirmation(HotelBookingModel model)
        {
            return View(model);
        }
    }
}