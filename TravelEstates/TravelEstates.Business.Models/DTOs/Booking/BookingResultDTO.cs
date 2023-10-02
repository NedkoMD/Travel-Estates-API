using TravelEstates.Data.Models.Entities.Base;

namespace TravelEstates.Business.Models.DTOs.Booking
{
    public class BookingResultDTO
    {
        public string Id { get; set; }

        public DateTime CheckInDate { get; set; }

        public DateTime CheckOutDate { get; set; }

        public RentProperty? RentProperty { get; set; }

        public User? User { get; set; }
    }
}
