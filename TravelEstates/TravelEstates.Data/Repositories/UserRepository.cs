using Microsoft.EntityFrameworkCore;
using TravelEstates.Data.Abstraction.Repositories;
using TravelEstates.Data.Models.Entities.Base;
using TravelEstates.Data.Repositories.Base;

namespace TravelEstates.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly TravelEstatesContext _travelEstatesContext;

        public UserRepository(TravelEstatesContext travelEstatesContext) : base(travelEstatesContext)
        {
            _travelEstatesContext = travelEstatesContext;
        }

        public async Task<bool> UserExistsAsync(string userId)
        {
            var user = await _travelEstatesContext.Users.FirstOrDefaultAsync(u => u.Id == userId);

            return user != null;
        }
    }
}
