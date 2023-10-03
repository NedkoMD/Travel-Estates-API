using TravelEstates.Business.Models.DTOs.BookingDTOs;
using TravelEstates.Business.Models.Results.Base;

namespace TravelEstates.Business.Abstraction.Services
{
    public interface IBookingService
    {
        Task<IResult<IEnumerable<BookingResultDTO>>> GetAllAsync(string userId);

        public Task<IResult<BookingResultDTO>> GetByIdAsync(string id);

        public Task<IResult<BookingResultDTO>> AddAsync(BookingCreateDTO bookingAddDTO);

        public Task<IResult<BookingResultDTO>> UpdateAsync(string id, BookingUpdateDTO bookingUpdateDTO);

        public Task<IResult<BookingDeleteDTO>> DeleteAsync(string id);
    }
}
