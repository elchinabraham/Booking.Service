using Booking.Service.Domain.Home;
using Microsoft.EntityFrameworkCore;

namespace Booking.Service.Repository.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Home> Homes { get; set; }
    }
}
