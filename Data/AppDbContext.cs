using Microsoft.EntityFrameworkCore;
using WebApplication4.Models;

namespace WebApplication4.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<HotelBookingModel> HotelBookings { get; set; }
        public DbSet<FlightBookingModel> FlightBookings { get; set; }
        public DbSet<CarRentalModel> CarRentals { get; set; }

   
    }
}

