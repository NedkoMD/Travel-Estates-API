using TravelEstates.Business.Models.Enums;
using TravelEstates.Business.Models.Results.Base;

namespace TravelEstates.Business.Models.Results
{
    public class BadRequestResult<T> : IResult<T>
    {
        public BadRequestResult(params string[] errorMessages)
        {
            ErrorMessages = errorMessages ?? Enumerable.Empty<string>();
        }

        public TravelEstatesStatusCode StatusCode => TravelEstatesStatusCode.BadRequest;

        public IEnumerable<string> ErrorMessages { get; set; }
        public T Data { get; }
    }
}
