namespace TravelEstates.Business.Models.DTOs
{
    public class BookingCancellationDTO
    {
        public string RentPropertyId { get; set; }

        public string UserId { get; set; }

        public DateTime CheckInDate { get; set; }

        public DateTime CheckOutDate { get; set; }
    }
}
