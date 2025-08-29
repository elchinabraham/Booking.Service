namespace Booking.Service.Infrastructure.DTO.Home;

/// <summary>
/// Get home request.
/// </summary>
/// <param name="StartDate">Start date.</param>
/// <param name="EndDate">End date.</param>
public record GetHomeRequest(DateTime StartDate, DateTime EndDate);
