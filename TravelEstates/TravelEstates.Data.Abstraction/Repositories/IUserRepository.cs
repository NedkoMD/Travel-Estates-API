using TravelEstates.Data.Abstraction.Repositories.Base;
using TravelEstates.Data.Models.Entities.Base;

namespace TravelEstates.Data.Abstraction.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        public Task<bool> UserExistsAsync(string userId);
    }
}
