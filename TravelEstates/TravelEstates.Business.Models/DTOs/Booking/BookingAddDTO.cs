using System.ComponentModel.DataAnnotations;
using TravelEstates.Business.Models.Utilities;

namespace TravelEstates.Business.Models.DTOs.Booking
{
    public class BookingAddDTO
    {
        [Required(ErrorMessage = BookingMessages.RentPropertyIdRequired)]
        public string RentPropertyId { get; set; }

        [Required(ErrorMessage = BookingMessages.UserIdRequired)]
        public string UserId { get; set; }

        [Required(ErrorMessage = BookingMessages.CheckInDateRequired)]
        [DataType(DataType.Date)]
        [Display(Name = BookingMessages.CheckInDateName)]
        public DateTime CheckInDate { get; set; }

        [Required(ErrorMessage = BookingMessages.CheckOutDateRequired)]
        [DataType(DataType.Date)]
        [Display(Name = BookingMessages.CheckOutDateName)]
        public DateTime CheckOutDate { get; set; }
    }
}
