using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication4.Data;
using WebApplication4.Models;

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
			var carRentals = _db.Listings.Where(l => l.Type == "Car").ToList();

			ViewBag.CarModels = new SelectList(carRentals.Select(l => l.Name).Distinct());

			return View();
		}

		[HttpPost]
		public ActionResult RentCar(CarRentalModel model)
		{
			if (ModelState.IsValid)
			{


				return RedirectToAction("CarRentalConfirmation", "Booking", model);
			}

            var carRentals = _db.Listings.Where(l => l.Type == "Car").ToList();
            ViewBag.CarModels = new SelectList(carRentals.Select(l => l.Name).Distinct());

         

            return View("CarRental", model);
		}

		public ActionResult CarRentalConfirmation(CarRentalModel model)
		{
			return View(model);
		}

		public ActionResult Hotel()
		{
			var hotels = _db.Listings.Where(l => l.Type == "Hotel").ToList();

			ViewBag.Provinces = new SelectList(new[]
			{
				"Alberta", "British Columbia", "Manitoba", "New Brunswick",
				"Newfoundland and Labrador", "Nova Scotia", "Ontario", "Prince Edward Island",
				"Quebec", "Saskatchewan"
			});

			ViewBag.Hotels = new SelectList(hotels.Select(l => l.Name).Distinct());


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

		public IActionResult Listings()
		{
			return View();
		}

	}
}