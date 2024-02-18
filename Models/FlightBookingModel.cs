using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class FlightBookingModel
    {
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; } // Changed from GuestEmail to Email

        [Required(ErrorMessage = "Location is required")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Departure Date is required")]
        [DataType(DataType.Date)]
        public DateTime DepartureDate { get; set; }

        [Required(ErrorMessage = "Arrival Date is required")]
        [DataType(DataType.Date)]
        public DateTime ArrivalDate { get; set; }

        // Add Destination property
        [Required(ErrorMessage = "Destination is required")]
        public string Destination { get; set; }
    }
}
