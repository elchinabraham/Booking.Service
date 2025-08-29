using AutoMapper;
using Booking.Service.Domain.Home;
using Booking.Service.Infrastructure.DTO.Home;
using Booking.Service.Infrastructure.ResultPattern;
using Booking.Service.Repository.HomeRepository;
using Microsoft.Extensions.Logging;

namespace Booking.Service.Infrastructure.HomeService
{
    /// <summary>
    /// Home service.
    /// </summary>
    public class HomeService(ILogger<HomeService> logger, IHomeRepository homeRepository, IMapper mapper) : IHomeService
    {
        /// <summary>
        /// Get available homes.
        /// </summary>
        /// <param name="getHomeRequest">Get homes request.</param>
        /// <returns>List of homes.</returns>
        public async Task<ServiceResult<List<GetHomeResponse>>> GetAvailableHomesAsync(GetHomeRequest getHomeRequest)
        {
            logger.LogInformation($"Starts getting all homes between {getHomeRequest.StartDate} and {getHomeRequest.EndDate} time slots");

            var homeQuery = mapper.Map<HomeQuery>(getHomeRequest);

            var homes = await homeRepository.GetAllAsync(homeQuery);

            logger.LogInformation($"Ends getting all homes between {getHomeRequest.StartDate} and {getHomeRequest.EndDate} time slots. Results count: {homes.Count}");

            var homesResponse = mapper.Map<List<GetHomeResponse>>(homes);

            var serviceResult = ServiceResult<List<GetHomeResponse>>.Success(homesResponse);

            return serviceResult;
        }
    }
}
