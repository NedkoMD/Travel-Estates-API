namespace TravelEstates.Business.Models.DTOs.BookingDTOs
{
    public class BookingResultDTO
    {
        public string Id { get; set; }

        public DateTime CheckInDate { get; set; }

        public DateTime CheckOutDate { get; set; }

        public string RentPropertyName { get; set; }

        public string UserName { get; set; }
    }
}
