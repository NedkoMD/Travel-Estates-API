using TravelEstates.Data.Models.Entities.Base;

namespace TravelEstates.Business.Models.DTOs.RentPropertyDTOs
{
    public class RentPropertyResultDTO
    {
        public string Id { get; set; }

        public string PropertyTypeId { get; set; }

        public string PropertyTypeName { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public int RoomCount { get; set; }

        public string Description { get; set; }

        public double PricePerNight { get; set; }
    }
}
