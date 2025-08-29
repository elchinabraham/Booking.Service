using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace Booking.Service.Domain.Home
{
    /// <summary>
    /// Home.
    /// </summary>
    public class Home
    {
        /// <summary>
        /// Home identifier.
        /// </summary>
        public Guid HomeId { get; set; }

        /// <summary>
        /// Home name.
        /// </summary>
        public string HomeName { get; set; }

        /// <summary>
        /// Available slots.
        /// </summary>
        [NotMapped]
        public HashSet<DateTime> AvailableSlots { get; set; } = new HashSet<DateTime>();

        public string AvailableSlotsJson
        {
            get => JsonSerializer.Serialize(AvailableSlots);
            set => AvailableSlots = string.IsNullOrEmpty(value)
                ? new HashSet<DateTime>()
                : JsonSerializer.Deserialize<HashSet<DateTime>>(value);
        }

        /// <summary>
        /// Is available?
        /// </summary>
        /// <param name="startDate">Start date.</param>
        /// <param name="endDate">End date.</param>
        /// <returns></returns>
        public bool IsAvailable(DateTime startDate, DateTime endDate)
        {
            var current = startDate;

            while (current <= endDate)
            {
                if (!AvailableSlots.Contains(current))
                    return false;

                current = current.AddDays(1);
            }

            return true;
        }
    }
}
