namespace TravelEstates.Business.Models.DTOs
{
    public class BookingUpdateDTO
    {
        public string Id { get; set; }

        public string RentPropertyId { get; set; }

        public string UserId { get; set; }

        public DateTime CheckInDate { get; set; }

        public DateTime CheckOutDate { get; set; }
    }
}
