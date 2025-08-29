using Booking.Service.Domain.Home;
using Microsoft.EntityFrameworkCore;

namespace Booking.Service.Repository.Data
{
    /// <summary>
    /// Application database context.
    /// </summary>
    /// <param name="options">Options.</param>
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        /// <summary>
        /// Homes entity set.
        /// </summary>
        public DbSet<Home> Homes { get; set; }
    }
}
