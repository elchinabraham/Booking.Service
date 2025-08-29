using Booking.Service.Infrastructure.DTO.Home;
using FluentValidation;

namespace Booking.Service.WebApi.Validations.Home
{
    /// <summary>
    /// Get home request validator.
    /// </summary>
    public class GetHomeRequestValidator : AbstractValidator<GetHomeRequest>
    {
        /// <summary>
        /// Creates validator.
        /// </summary>
        public GetHomeRequestValidator()
        {
            RuleFor(x => x.StartDate)
                .GreaterThan(DateTime.Today.AddDays(-1))
                .WithMessage("Start date must be later than today.");

            RuleFor(x => x.EndDate)
                .GreaterThan(DateTime.Today.AddDays(-1))
                .WithMessage("End date must be later than today.")
                .GreaterThan(x => x.StartDate)
                .WithMessage("End date must be later than start date.");
        }
    }
}
