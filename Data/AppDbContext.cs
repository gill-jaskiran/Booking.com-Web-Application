using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Models;
using Listing = WebApplication4.Models.Listing;

namespace WebApplication4.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<HotelBookingModel> HotelBookings { get; set; }
        public DbSet<FlightBookingModel> FlightBookings { get; set; }
        public DbSet<CarRentalModel> CarRentals { get; set; }
        public DbSet<Listing> Listings { get; set; }
    }
}