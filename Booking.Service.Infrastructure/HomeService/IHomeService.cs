using Booking.Service.Infrastructure.DTO.Home;
using Booking.Service.Infrastructure.ResultPattern;

namespace Booking.Service.Infrastructure.HomeService
{
    /// <summary>
    /// Home service.
    /// </summary>
    public interface IHomeService
    {
        /// <summary>
        /// Get available homes.
        /// </summary>
        /// <param name="getHomeRequest">Get homes request.</param>
        /// <returns>List of homes.</returns>
        Task<ServiceResult<List<GetHomeResponse>>> GetAvailableHomesAsync(GetHomeRequest getHomeRequest);
    }
}
