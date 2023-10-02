using TravelEstates.Business.Models.DTOs.Booking;
using TravelEstates.Business.Models.Results.Base;

namespace TravelEstates.Business.Abstraction.Services
{
    public interface IBookingService
    {
        Task<IResult<ICollection<BookingResultDTO>>> GetAllAsync(string userId);

        public Task<IResult<BookingResultDTO>> GetByIdAsync(string id);

        public Task<IResult<BookingResultDTO>> AddAsync(BookingAddDTO bookingAddDTO);

        public Task<IResult<BookingResultDTO>> UpdateAsync(string id, BookingUpdateDTO bookingUpdateDTO);

        public Task<IResult<BookingCancellationDTO>> DeleteAsync(string id);
    }
}
