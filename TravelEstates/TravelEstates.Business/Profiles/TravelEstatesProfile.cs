using AutoMapper;
using TravelEstates.Business.Models.DTOs.Booking;
using TravelEstates.Data.Models.Entities.Base;

namespace TravelEstates.Business.Profiles
{
    public class TravelEstatesProfile : Profile
    {
        public TravelEstatesProfile()
        {
            CreateMap<Booking, BookingAddDTO>()
                .ReverseMap();
            CreateMap<Booking, BookingCancellationDTO>()
                .ReverseMap();
            CreateMap<Booking, BookingUpdateDTO>()
                .ReverseMap();
            CreateMap<Booking, BookingResultDTO>()
                .ReverseMap();
        }
    }
}
