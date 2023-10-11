using TravelEstates.Data.Abstraction.Repositories.Base;
using TravelEstates.Data.Models.Entities.Base;

namespace TravelEstates.Data.Abstraction.Repositories
{
    public interface IBookingRepository : IRepository<Booking>
    {
        Task<Booking> GetByIdAsync(string id);
    }
}
