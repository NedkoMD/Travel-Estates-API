using TravelEstates.Data.Abstraction.Repositories;
using TravelEstates.Data.Models.Entities.Base;
using TravelEstates.Data.Repositories.Base;

namespace TravelEstates.Data.Repositories
{
    public class TokenRepository : Repository<Token>, ITokenRepository
    {
        private readonly TravelEstatesContext _travelEstatesContext;

        public TokenRepository(TravelEstatesContext travelEstatesContext) : base(travelEstatesContext)
        {
            _travelEstatesContext = travelEstatesContext;
        }
    }
}
