namespace TravelEstates.Data.Models.Entities.Base
{
    public class RentProperty
    {
        public string Id { get; set; }

        public string PropertyTypeId { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public int RoomCount { get; set; }

        public string Description { get; set; }

        public double PricePerNight { get; set; }

        // Navigation property for bookings
        public ICollection<Booking> Bookings { get; set; }

        public PropertyType PropertyType { get; set; }
    }
}
