using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class CarRentalModel
    {
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Car Model is required")]
        public string CarModel { get; set; }

        [Required(ErrorMessage = "Rental Start Date is required")]
        [DataType(DataType.Date)]
        public DateTime RentalStartDate { get; set; }

        [Required(ErrorMessage = "Rental End Date is required")]
        [DataType(DataType.Date)]
        public DateTime RentalEndDate { get; set; }
    }
}
