using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
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

        public async Task<ICollection<Booking>> GetAllAsync(Expression<Func<Booking, bool>> expression)
        {
            var query = _travelEstatesContext.Bookings
                .Where(expression)
                .Select(b => new Booking
                {
                    Id = b.Id,
                    CheckInDate = b.CheckInDate,
                    CheckOutDate = b.CheckOutDate,
                    RentProperty = new RentProperty
                    {
                        Name = b.RentProperty.Name
                    },
                    User = new User
                    {
                        FirstName = b.User.FirstName,
                        LastName = b.User.LastName
                    }
                });

            return await query.ToListAsync();
        }

        public async Task<Booking> GetByIdAsync(string id)
        {
            return await _travelEstatesContext.Bookings
                .Where(b => b.Id == id)
                .Select(b => new Booking
                {
                    Id = b.Id,
                    CheckInDate = b.CheckInDate,
                    CheckOutDate = b.CheckOutDate,
                    RentProperty = new RentProperty
                    {
                        Name = b.RentProperty.Name
                    },
                    User = new User
                    {
                        FirstName = b.User.FirstName,
                        LastName = b.User.LastName
                    }
                })
                .FirstOrDefaultAsync();
        }
    }
}
