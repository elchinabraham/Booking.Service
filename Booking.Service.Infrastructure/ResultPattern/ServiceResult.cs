using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json.Serialization;

namespace Booking.Service.Infrastructure.ResultPattern
{
    /// <summary>
    /// Generic: Service result.
    /// </summary>
    /// <typeparam name="T">Generic type.</typeparam>
    public class ServiceResult<T>
    {
        /// <summary>
        /// Problem details.
        /// </summary>
        public ProblemDetails? ProblemDetails { get; set; }
        
        /// <summary>
        /// Generic type: T
        /// </summary>
        public T? Data { get; set; }

        /// <summary>
        /// Error message.
        /// </summary>
        public List<string>? ErrorMessage { get; set; }

        // We do not need to indicate to caller following fields.
        [JsonIgnore] public bool IsSuccess => ErrorMessage == null || ErrorMessage.Count == 0;
        [JsonIgnore] public bool IsFail => !IsSuccess;
        [JsonIgnore] public HttpStatusCode Status { get; set; }
        [JsonIgnore] public string? UrlAsCreated { get; set; }

        /// <summary>
        /// Success.
        /// </summary>
        /// <param name="data">Success's data.</param>
        /// <param name="status">Success's status.</param>
        /// <returns></returns>
        public static ServiceResult<T> Success(T data, HttpStatusCode status = HttpStatusCode.OK)
        {
            return new ServiceResult<T>()
            {
                Data = data,
                Status = status
            };
        }

        /// <summary>
        /// Success as created.
        /// </summary>
        /// <param name="data">Success's data.</param>
        /// <param name="urlAsCreated">Url as created.</param>
        /// <returns>Service result of Generic T.</returns>
        public static ServiceResult<T> SuccessAsCreated(T data, string urlAsCreated)
        {
            return new ServiceResult<T>()
            {
                Data = data,
                Status = HttpStatusCode.Created,
                UrlAsCreated = urlAsCreated
            };
        }

        /// <summary>
        /// Fail.
        /// </summary>
        /// <param name="errorMessage">Error message.</param>
        /// <param name="status">Fail's status.</param>
        /// <returns>Service result of Generic T.</returns>
        public static ServiceResult<T> Fail(List<string> errorMessage,
            HttpStatusCode status = HttpStatusCode.BadRequest)
        {
            return new ServiceResult<T>()
            {
                ErrorMessage = errorMessage,
                Status = status
            };
        }

        /// <summary>
        /// Fail.
        /// </summary>
        /// <param name="problemDetails">Problem details.</param>
        /// <param name="status">Fail's status.</param>
        /// <returns>Service result of Generic T.</returns>
        public static ServiceResult<T> Fail(ProblemDetails problemDetails,
            HttpStatusCode status = HttpStatusCode.BadRequest)
        {
            return new ServiceResult<T>()
            {
                ProblemDetails = problemDetails,
                Status = status
            };
        }

        /// <summary>
        /// Fail.
        /// </summary>
        /// <param name="errorMessage">Error message.</param>
        /// <param name="status">Fail's status.</param>
        /// <returns>Service result of Generic T.</returns>
        public static ServiceResult<T> Fail(string errorMessage, HttpStatusCode status = HttpStatusCode.BadRequest)
        {
            return new ServiceResult<T>()
            {
                ErrorMessage = [errorMessage],
                Status = status
            };
        }
    }

    /// <summary>
    /// Service result.
    /// </summary>
    public class ServiceResult
    {
        /// <summary>
        /// Problem details.
        /// </summary>
        public ProblemDetails? ProblemDetails { get; set; }

        /// <summary>
        /// Error message.
        /// </summary>
        public List<string>? ErrorMessage { get; set; }

        // We do not need to indicate to caller following fields.
        [JsonIgnore] public bool IsSuccess => ErrorMessage == null || ErrorMessage.Count == 0;
        [JsonIgnore] public bool IsFail => !IsSuccess;
        [JsonIgnore] public HttpStatusCode Status { get; set; }

        /// <summary>
        /// Success.
        /// </summary>
        /// <param name="status">Success's status.</param>
        /// <returns>Service result.</returns>
        public static ServiceResult Success(HttpStatusCode status = HttpStatusCode.OK)
        {
            return new ServiceResult()
            {
                Status = status
            };
        }

        /// <summary>
        /// Fail.
        /// </summary>
        /// <param name="errorMessage">Error message.</param>
        /// <param name="status">Fail's status.</param>
        /// <returns>Service result.</returns>
        public static ServiceResult Fail(List<string> errorMessage,
            HttpStatusCode status = HttpStatusCode.BadRequest)
        {
            return new ServiceResult()
            {
                ErrorMessage = errorMessage,
                Status = status
            };
        }

        /// <summary>
        /// Service result.
        /// </summary>
        /// <param name="problemDetails">Problem details.</param>
        /// <param name="status">Fail's status.</param>
        /// <returns>Service result.</returns>
        public static ServiceResult Fail(ProblemDetails problemDetails,
         HttpStatusCode status = HttpStatusCode.BadRequest)
        {
            return new ServiceResult()
            {
                ProblemDetails = problemDetails,
                Status = status
            };
        }

        /// <summary>
        /// Fail.
        /// </summary>
        /// <param name="errorMessage">Error message.</param>
        /// <param name="status">Fail's status.</param>
        /// <returns>Service result.</returns>
        public static ServiceResult Fail(string errorMessage, HttpStatusCode status = HttpStatusCode.BadRequest)
        {
            return new ServiceResult()
            {
                ErrorMessage = [errorMessage],
                Status = status
            };
        }
    }
}
