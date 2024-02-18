using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication4.Controllers
{
    public class BookingController : Controller
    {

        // GET: Booking/Flight
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
                // Save booking details or send confirmation email here
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



    }
}