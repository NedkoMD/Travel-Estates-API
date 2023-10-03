namespace TravelEstates.Business.Models.DTOs.BookingDTOs
{
    public class BookingDeleteDTO
    {
        public string RentPropertyId { get; set; }

        public string UserId { get; set; }

        public DateTime CheckInDate { get; set; }

        public DateTime CheckOutDate { get; set; }
    }
}
