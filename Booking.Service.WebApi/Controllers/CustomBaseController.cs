using Booking.Service.Infrastructure.ResultPattern;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Booking.Service.WebApi.Controllers
{
    /// <summary>
    /// Custom base controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CustomBaseController : ControllerBase
    {
        /// <summary>
        /// create action result.
        /// </summary>
        /// <typeparam name="T">Generic: T.</typeparam>
        /// <param name="result">Result.</param>
        /// <returns>IAction result.</returns>
        [NonAction]
        public IActionResult CreateActionResult<T>(ServiceResult<T> result)
        {
            return result.Status switch
            {
                HttpStatusCode.NoContent => NoContent(),
                HttpStatusCode.Created => Created(result.UrlAsCreated, result),
                HttpStatusCode.OK => Ok(result.Data),
                HttpStatusCode.NotFound => NotFound(null),
                _ => new ObjectResult(result.ProblemDetails) { StatusCode = result.Status.GetHashCode() }
            };
        }

        /// <summary>
        /// Create action result.
        /// </summary>
        /// <param name="result">Result.</param>
        /// <returns>IActionResult.</returns>
        [NonAction]
        public IActionResult CreateActionResult(ServiceResult result)
        {
            return result.Status switch
            {
                HttpStatusCode.NoContent => new ObjectResult(null) { StatusCode = result.Status.GetHashCode() },
                HttpStatusCode.NotFound => NotFound(result.ErrorMessage),
                _ => new ObjectResult(result.ProblemDetails) { StatusCode = result.Status.GetHashCode() }
            };
        }
    }
}
