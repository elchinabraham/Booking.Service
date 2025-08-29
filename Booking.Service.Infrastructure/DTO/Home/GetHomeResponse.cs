namespace Booking.Service.Infrastructure.DTO.Home;

/// <summary>
/// Get home request.
/// </summary>
public record GetHomeResponse(Guid HomeId, string HomeName, List<DateTime> AvailableSlots);