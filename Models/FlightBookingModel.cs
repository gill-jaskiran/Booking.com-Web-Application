using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
	public class FlightBookingModel
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "First Name is required")]
		public string FirstName { get; set; }

		[Required(ErrorMessage = "Last Name is required")]
		public string LastName { get; set; }

		[Required(ErrorMessage = "Email is required")]
		[EmailAddress(ErrorMessage = "Invalid email address")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Location is required")]
		public string Location { get; set; }

		[Required(ErrorMessage = "Departure Date is required")]
		[DataType(DataType.Date)]
		public DateTime DepartureDate { get; set; }

		[Required(ErrorMessage = "Arrival Date is required")]
		[DataType(DataType.Date)]
		public DateTime ArrivalDate { get; set; }
	}
}
