using TravelEstates.Data.Abstraction.Repositories;
using TravelEstates.Data.Models.Entities.Base;
using TravelEstates.Data.Repositories.Base;

namespace TravelEstates.Data.Repositories
{
    public class BookingRepository : Repository<Booking>, IBookingRepository
    {
        private readonly TravelEstatesContext _travelEstatesContext;

        public BookingRepository(TravelEstatesContext travelEstatesContext) : base(travelEstatesContext)
        {
            _travelEstatesContext = travelEstatesContext;
        }
    }
}
