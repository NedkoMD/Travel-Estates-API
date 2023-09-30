using AutoMapper;
using TravelEstates.Business.Abstraction.Factories;
using TravelEstates.Business.Abstraction.Services;
using TravelEstates.Business.Models.DTOs;
using TravelEstates.Data.Abstraction.Repositories;

namespace TravelEstates.Business.Services
{
    public class BookingService : IBookingService
    {
        private readonly IMapper _mapper;
        private readonly IResultFactory _resultFactory;
        private readonly IBookingRepository _bookingRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRentPropertyRepository _rentPropertyRepository;

        public BookingService(
            IMapper mapper, 
            IResultFactory resultFactory, 
            IBookingRepository bookingRepository,
            IUserRepository userRepository,
            IRentPropertyRepository rentPropertyRepository)
        {
            _mapper = mapper;
            _resultFactory = resultFactory;
            _bookingRepository = bookingRepository;
            _userRepository = userRepository;
            _rentPropertyRepository = rentPropertyRepository;
        }

        public async Task<ICollection<BookingResultDTO>> GetAllAsync(string userId, string rentPropertyId)
        {
            var bookings = await _bookingRepository.GetAllAsync(b =>
            (userId == default || userId == b.UserId) &&
            (rentPropertyId == default || rentPropertyId == b.RentPropertyId));

            var bookingResultDTO = _mapper.Map<ICollection<BookingResultDTO>>(bookings);

            return bookingResultDTO;
        }
    }
}
