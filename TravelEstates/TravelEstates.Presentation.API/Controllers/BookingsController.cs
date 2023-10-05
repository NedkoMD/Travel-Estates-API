using Microsoft.AspNetCore.Mvc;
using TravelEstates.Business.Abstraction.Services;
using TravelEstates.Business.Models.DTOs.BookingDTOs;
using TravelEstates.Presentation.API.Extensions;

namespace TravelEstates.API.Controllers
{
    [Route("api/bookings")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllByUserIdAsync([FromQuery] string userId)
        {
            var result = await _bookingService.GetAllByUserIdAsync(userId);

            return this.HandleResponse(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] string id)
        {
            var result = await _bookingService.GetByIdAsync(id);

            return this.HandleResponse(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] BookingCreateDTO bookingAddDTO)
        {
            var result = await _bookingService.AddAsync(bookingAddDTO);
            
            return this.HandleResponse(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(string id, [FromBody] BookingUpdateDTO bookingUpdateDTO)
        {
            var result = await _bookingService.UpdateAsync(id, bookingUpdateDTO);

            return this.HandleResponse(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var result = await _bookingService.DeleteAsync(id);
            
            return this.HandleResponse(result);
        }
    }
}
