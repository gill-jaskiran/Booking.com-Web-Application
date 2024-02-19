using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication4.Models;
using WebApplication4.Data; 

namespace WebApplication4.Controllers
{
    public class BookingController : Controller
    {
        private readonly AppDbContext _db;

        public BookingController(AppDbContext db)
        {

            _db = db;

        }
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
            if (ModelState.IsValid)
            {
      
                model.Location = Request.Form["Location"].ToString();

               

                return RedirectToAction("BookingConfirmation", "Home", model);
            }

            ViewBag.Provinces = new SelectList(new[]
            {
                "Alberta", "British Columbia", "Manitoba", "New Brunswick",
                "Newfoundland and Labrador", "Nova Scotia", "Ontario", "Prince Edward Island",
                "Quebec", "Saskatchewan"
            });
            return View("Flight", model);
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
            if (ModelState.IsValid)
            {
             

                return RedirectToAction("CarRentalConfirmation", "Booking", model);
            }

            ViewBag.CarModels = new SelectList(new[]
            {
                "BMW", "Tesla Model X", "Toyota", "Honda Civic", "Honda Accord", "Ford F150", "Bentley",
                "Nissan Altima", "Hyundai", "Acura","Kia", "Subaru",
                "Volkswagen", "Mazda"
            });
            return View("CarRental", model);
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

            return View("Hotel");
        }

        [HttpPost]
        public ActionResult BookHotel(HotelBookingModel model)
        {
            if (ModelState.IsValid)
            {
               
                return RedirectToAction("HotelConfirmation", "Booking", model);
            }

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

            return View("Hotel", model);
        }

        public ActionResult HotelConfirmation(HotelBookingModel model)
        {
            return View(model);
        }

    }
}