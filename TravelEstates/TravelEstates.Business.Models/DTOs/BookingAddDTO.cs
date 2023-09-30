using System.ComponentModel.DataAnnotations;

namespace TravelEstates.Business.Models.DTOs
{
    public class BookingAddDTO
    {
        [Required]
        public string RentPropertyId { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public DateTime CheckInDate { get; set; }

        [Required]
        public DateTime CheckOutDate { get; set; }
    }
}
