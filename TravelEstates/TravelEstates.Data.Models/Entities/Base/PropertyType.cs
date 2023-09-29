namespace TravelEstates.Data.Models.Entities.Base
{
    public class PropertyType
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public ICollection<RentProperty> Properties { get; set; }
    }
}
