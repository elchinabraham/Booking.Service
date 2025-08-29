using Booking.Service.Infrastructure.HomeService;
using Booking.Service.Repository.HomeRepository;

namespace Booking.Service.WebApi.Configuration
{
    /// <summary>
    /// Injected services
    /// </summary>
    public static class InjectedServices
    {
        /// <summary>
        /// Inject services.
        /// </summary>
        /// <param name="services"></param>
        public static void InjectServices(this IServiceCollection services) => services
            .AddTransient<IHomeRepository, HomeRepository>()
            .AddTransient<IHomeService, HomeService>();
    }
}
