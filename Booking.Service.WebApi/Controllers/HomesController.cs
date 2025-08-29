using Booking.Service.Infrastructure.DTO.Home;
using Booking.Service.Infrastructure.HomeService;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Service.WebApi.Controllers
{
    /// <summary>
    /// Homes controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class HomesController(IHomeService homeService) : CustomBaseController
    {
        /// <summary>
        /// Get available homes.
        /// </summary>
        /// <param name="request">Get home request.</param>
        /// <returns>Task of IActionResult.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAvailableHomesAsync([FromQuery] GetHomeRequest request)
        {
            var availableHomes = await homeService.GetAvailableHomesAsync(request);

            return CreateActionResult(availableHomes);
        }
    }
}
