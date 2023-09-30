using TravelEstates.Business.Models.Enums;
using TravelEstates.Business.Models.Results.Base;

namespace TravelEstates.Business.Models.Results
{
    public class NoContentResult<T> : IResult<T>
    {
        public TravelEstatesStatusCode StatusCode => TravelEstatesStatusCode.NoContent;

        public IEnumerable<string> ErrorMessages => Enumerable.Empty<string>();

        public T Data { get; }
    }
}
