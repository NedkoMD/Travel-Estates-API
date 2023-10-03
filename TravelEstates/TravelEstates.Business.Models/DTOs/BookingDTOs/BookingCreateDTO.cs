using System.ComponentModel.DataAnnotations;
using TravelEstates.Business.Models.Utilities;

namespace TravelEstates.Business.Models.DTOs.BookingDTOs
{
    public class BookingCreateDTO
    {
        [Required(ErrorMessage = BookingDTOMessages.RentPropertyIdRequired)]
        public string RentPropertyId { get; set; }

        [Required(ErrorMessage = BookingDTOMessages.UserIdRequired)]
        public string UserId { get; set; }

        [Required(ErrorMessage = BookingDTOMessages.CheckInDateRequired)]
        [DataType(DataType.Date)]
        [Display(Name = BookingDTOMessages.CheckInDateName)]
        public DateTime CheckInDate { get; set; }

        [Required(ErrorMessage = BookingDTOMessages.CheckOutDateRequired)]
        [DataType(DataType.Date)]
        [Display(Name = BookingDTOMessages.CheckOutDateName)]
        public DateTime CheckOutDate { get; set; }
    }
}
