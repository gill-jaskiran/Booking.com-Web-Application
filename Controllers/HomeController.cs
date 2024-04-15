using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
	/*[Authorize(Roles = "Admin")]*/
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			return View();
		}

		/*[Authorize(Roles = "Admin")]*/
		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

		public IActionResult BookingConfirmation(FlightBookingModel model)
		{
			return View(model);
		}


		public IActionResult Flight()
		{
			ViewBag.Provinces = new SelectList(new[]
			{
				"Alberta", "British Columbia", "Manitoba", "New Brunswick",
				"Newfoundland and Labrador", "Nova Scotia", "Ontario", "Prince Edward Island",
				"Quebec", "Saskatchewan"
			});
			return View();

		}

		public IActionResult NotFound(int statusCode)
		{
			if (statusCode == 404)
			{
				return View("NotFound");
			}
			return View("Error");
		}

        public IActionResult InternalServerError(int statusCode)
        {
            if (statusCode == 500)
            {
                return View("InternalServerError");
            }
            return View("Error");
        }



    }


}