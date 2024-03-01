using HotelManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<HotelRooms> HotelRooms { get; set; }
        public DbSet<Payments> Payments { get; set; }
        public DbSet<Reservations> Reservations { get; set; }
    }
}
