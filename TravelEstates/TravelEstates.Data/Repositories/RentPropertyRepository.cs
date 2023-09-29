using TravelEstates.Data.Abstraction.Repositories;
using TravelEstates.Data.Models.Entities.Base;
using TravelEstates.Data.Repositories.Base;

namespace TravelEstates.Data.Repositories
{
    public class RentPropertyRepository : Repository<RentProperty>, IRentPropertyRepository
    {
        private readonly TravelEstatesContext _travelEstatesContext;

        public RentPropertyRepository(TravelEstatesContext travelEstatesContext) : base(travelEstatesContext)
        {
            _travelEstatesContext = travelEstatesContext;
        }
    }
}
