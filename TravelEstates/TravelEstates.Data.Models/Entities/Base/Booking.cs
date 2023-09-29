namespace TravelEstates.Data.Models.Entities.Base
{
    public class Booking
    {
        // Composite key
        public string RentPropertyId { get; set; }

        public string UserId { get; set; }

        public DateTime CheckInDate { get; set; }

        public DateTime CheckOutDate { get; set; }

        // Navigation properties
        public RentProperty RentProperty { get; set; }

        public User User { get; set; }
    }
}