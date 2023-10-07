using AutoMapper;
using TravelEstates.Business.Abstraction.Factories;
using TravelEstates.Business.Abstraction.Services;
using TravelEstates.Business.Models.DTOs.BookingDTOs;
using TravelEstates.Business.Models.Results.Base;
using TravelEstates.Business.Models.Utilities;
using TravelEstates.Data.Abstraction.Repositories;
using TravelEstates.Data.Models.Entities.Base;

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

        public async Task<IResult<ICollection<BookingResultDTO>>> GetAllByUserIdAsync(string userId)
        {
            var userExists = await _userRepository.UserExistsAsync(userId);

            if (!userExists)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<ICollection<BookingResultDTO>>(BookingDTOMessages.UserNotFound);

                return notFoundResult;
            }

            var bookings = await _bookingRepository.GetAllAsync(b => userId == b.UserId);
            var bookingResultDTOs = _mapper.Map<ICollection<BookingResultDTO>>(bookings);

            if (!bookingResultDTOs.Any())
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<ICollection<BookingResultDTO>>(BookingDTOMessages.BookingNotFoundForUser);

                return notFoundResult;
            }

            return _resultFactory.GetOkResult(bookingResultDTOs);
        }



        public async Task<IResult<BookingResultDTO>> GetByIdAsync(string id)
        {
            var booking = await _bookingRepository.FindEntityAsync(b => b.Id == id);

            if (booking == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<BookingResultDTO>(BookingDTOMessages.BookingNotFound);

                return notFoundResult;
            }

            var bookingResultDTO = _mapper.Map<BookingResultDTO>(booking);
            var okResult = _resultFactory.GetOkResult<BookingResultDTO>();

            return okResult;
        }

        public async Task<IResult<BookingResultDTO>> AddAsync(BookingCreateDTO bookingAddDTO)
        {
            if (bookingAddDTO.CheckInDate >= bookingAddDTO.CheckOutDate)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<BookingResultDTO>(BookingDTOMessages.CheckInDateNotBeforeCheckOutDate);

                return badRequestResult;
            }

            var bookingEntity = _mapper.Map<Booking>(bookingAddDTO);

            await _bookingRepository.AddAsync(bookingEntity);

            var createdResultDTO = _mapper.Map<BookingResultDTO>(bookingEntity);
            var createdResult = _resultFactory.GetCreatedResult(createdResultDTO);

            return createdResult;
        }

        public async Task<IResult<BookingResultDTO>> UpdateAsync(string id, BookingUpdateDTO bookingUpdateDTO)
        {
            var existingBooking = await _bookingRepository.FindEntityAsync(b => b.Id == id);

            if (existingBooking == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<BookingResultDTO>(BookingDTOMessages.BookingNotFound);
                return notFoundResult;
            }

            _mapper.Map(bookingUpdateDTO, existingBooking);

            await _bookingRepository.UpdateAsync(existingBooking);

            var updatedResultDTO = _mapper.Map<BookingResultDTO>(existingBooking);
            var updatedResult = _resultFactory.GetOkResult(updatedResultDTO);

            return updatedResult;
        }

        public async Task<IResult<BookingDeleteDTO>> DeleteAsync(string id)
        {
            var existingBooking = await _bookingRepository.FindEntityAsync(b => b.Id == id);

            if (existingBooking == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<BookingDeleteDTO>(BookingDTOMessages.BookingNotFound);

                return notFoundResult;
            }

            await _bookingRepository.DeleteAsync(existingBooking);

            var okResult = _resultFactory.GetOkResult<BookingDeleteDTO>();

            return okResult;
        }
    }
}
