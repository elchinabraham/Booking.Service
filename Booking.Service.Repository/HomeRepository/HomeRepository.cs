using Booking.Service.Domain.Home;
using Booking.Service.Repository.Data;

namespace Booking.Service.Repository.HomeRepository
{
    /// <summary>
    /// Home repository.
    /// </summary>
    public class HomeRepository : IHomeRepository
    {
        private readonly AppDbContext _context;

        /// <summary>
        /// Creates repository.
        /// </summary>
        /// <param name="context">App database context.</param>
        public HomeRepository(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get all homes.
        /// </summary>
        /// <param name="homeQuery">Home query.</param>
        /// <returns>List of homes.</returns>
        public async Task<List<Home>> GetAllAsync(HomeQuery homeQuery)
        {
            var startDate = homeQuery.StartDate;
            var endDate = homeQuery.EndDate;

            var homes = _context.Homes
                .AsEnumerable() 
                .Where(h => h.IsAvailable(startDate, endDate))
                .ToList();

            return await Task.FromResult(homes);
        }
    }
}
