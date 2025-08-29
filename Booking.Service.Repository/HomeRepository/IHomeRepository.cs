using Booking.Service.Domain.Home;

namespace Booking.Service.Repository.HomeRepository
{
    /// <summary>
    /// Home repository.
    /// </summary>
    public interface IHomeRepository
    {
        /// <summary>
        /// Get all homes.
        /// </summary>
        /// <param name="homeQuery">Home query.</param>
        /// <returns>List of homes.</returns>
        Task<List<Home>> GetAllAsync(HomeQuery homeQuery);
    }
}
