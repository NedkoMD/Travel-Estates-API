using TravelEstates.Data.Abstraction.Repositories;
using TravelEstates.Data.Models.Entities.Base;
using TravelEstates.Data.Repositories.Base;

namespace TravelEstates.Data.Repositories
{
    public class PropertyTypeRepository : Repository<PropertyType>, IPropertyTypeRepository
    {
        private readonly TravelEstatesContext _travelEstatesContext;

        public PropertyTypeRepository(TravelEstatesContext travelEstatesContext) : base(travelEstatesContext)
        {
            _travelEstatesContext = travelEstatesContext;
        }
    }
}
