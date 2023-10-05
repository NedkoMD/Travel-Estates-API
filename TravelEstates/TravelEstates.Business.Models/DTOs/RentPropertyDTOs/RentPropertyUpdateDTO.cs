using System.ComponentModel.DataAnnotations;
using TravelEstates.Business.Models.Utilities;

namespace TravelEstates.Business.Models.DTOs.RentPropertyDTOs
{
    public class RentPropertyUpdateDTO
    {
        [Required(ErrorMessage = RentPropertyDTOMessages.PropertyTypeRequired)]
        public string PropertyTypeId { get; set; }

        [Required(ErrorMessage = RentPropertyDTOMessages.PropertyNameRequired)]
        public string Name { get; set; }

        [Required(ErrorMessage = RentPropertyDTOMessages.PropertyLocationRequired)]
        public string Location { get; set; }

        [Required(ErrorMessage = RentPropertyDTOMessages.PropertyRoomCountRequired)]
        public int RoomCount { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = RentPropertyDTOMessages.PricePerNightRequired)]
        public double PricePerNight { get; set; }
    }
}
