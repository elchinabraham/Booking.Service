using AutoMapper;
using Booking.Service.Domain.Home;
using Booking.Service.Infrastructure.DTO.Home;

namespace Booking.Service.Infrastructure
{
    /// <summary>
    /// Mapping profile.
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Creates profile.
        /// </summary>
        public MappingProfile()
        {
            CreateHomeMapping();
        }

        /// <summary>
        /// create home mapping.
        /// </summary>
        private void CreateHomeMapping()
        {
            CreateMap<GetHomeRequest, HomeQuery>();
            CreateMap<Home, GetHomeResponse>();
        }
    }
}
