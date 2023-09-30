using TravelEstates.Business.Models.Enums;
using TravelEstates.Business.Models.Results.Base;

namespace TravelEstates.Business.Models.Results
{
    public class NotFoundResult<T> : IResult<T>
    {
        public NotFoundResult(params string[] errorMessages)
        {
            ErrorMessages = errorMessages ?? Enumerable.Empty<string>();
        }

        public TravelEstatesStatusCode StatusCode => TravelEstatesStatusCode.NotFound;

        public IEnumerable<string> ErrorMessages { get; set; }
        public T Data { get; }
    }
}
