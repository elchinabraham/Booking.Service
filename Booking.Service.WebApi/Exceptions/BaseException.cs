using System.Net;

namespace Booking.Service.WebApi.Exceptions
{
    /// <summary>
    /// Base exception.
    /// </summary>
    public class BaseException : Exception
    {
        /// <summary>
        /// Status code.
        /// </summary>
        public HttpStatusCode StatusCode { get; }

        /// <summary>
        /// Creates object.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="statusCode">Status code.</param>
        public BaseException(string message, HttpStatusCode statusCode = HttpStatusCode.InternalServerError)
            : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
