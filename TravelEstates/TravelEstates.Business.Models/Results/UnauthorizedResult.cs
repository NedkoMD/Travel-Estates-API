
using TravelEstates.Business.Models.Enums;
using TravelEstates.Business.Models.Results.Base;

namespace TravelEstates.Business.Models.Results
{
    public class UnauthorizedResult<T> : IResult<T>
    {
        public UnauthorizedResult(params string[] errorMessages)
        {
            ErrorMessages = errorMessages ?? Enumerable.Empty<string>();
        }

        public TravelEstatesStatusCode StatusCode => TravelEstatesStatusCode.Unauthorized;

        public IEnumerable<string> ErrorMessages { get; set; }
        public T Data { get; }
    }
}
