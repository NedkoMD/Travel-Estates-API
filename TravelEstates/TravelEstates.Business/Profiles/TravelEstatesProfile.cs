using AutoMapper;
using TravelEstates.Business.Models.DTOs.BookingDTOs;
using TravelEstates.Business.Models.DTOs.RentPropertyDTOs;
using TravelEstates.Business.Models.DTOs.UserDTOs;
using TravelEstates.Data.Models.Entities.Base;

namespace TravelEstates.Business.Profiles
{
    public class TravelEstatesProfile : Profile
    {
        public TravelEstatesProfile()
        {
            CreateMap<Booking, BookingCreateDTO>()
                .ReverseMap();
            CreateMap<Booking, BookingDeleteDTO>()
                .ReverseMap();
            CreateMap<Booking, BookingUpdateDTO>()
                .ReverseMap();
            CreateMap<Booking, BookingResultDTO>()
                .ReverseMap();
            CreateMap<Booking, BookingResultDTO>()
                .ForMember(dest => dest.RentPropertyName, opt => opt.MapFrom(src => src.RentProperty.Name))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.FirstName + " " + src.User.LastName));


            CreateMap<User, UserRegistrationDTO>()
                .ReverseMap();
            CreateMap<User, UserDeleteDTO>()
                .ReverseMap();
            CreateMap<User, UserUpdateDTO>()
                .ReverseMap();
            CreateMap<User, UserResultDTO>()
                .ReverseMap();

            CreateMap<RentProperty, RentPropertyCreateDTO>()
                .ReverseMap();
            CreateMap<RentProperty, RentPropertyDeleteDTO>()
                .ReverseMap();
            CreateMap<RentProperty, RentPropertyUpdateDTO>()
                .ReverseMap();
            CreateMap<RentProperty, RentPropertyResultDTO>()
                .ReverseMap();
        }
    }
}
