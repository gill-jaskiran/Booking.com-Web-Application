using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class HotelBookingModel
    {
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Location is required")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Hotel is required")]
        public string Hotel { get; set; }

        [Required(ErrorMessage = "Guests per room is required")]
        public int GuestsPerRoom { get; set; }
    }
}
