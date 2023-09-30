using TravelEstates.Business.Models.Enums;
using TravelEstates.Business.Models.Results.Base;

namespace TravelEstates.Business.Models.Results
{
    public class CreatedResult<T> : IResult<T>
    {
        public CreatedResult(T data)
        {
            Data = data;
        }

        public TravelEstatesStatusCode StatusCode => TravelEstatesStatusCode.Created;

        public IEnumerable<string> ErrorMessages => Enumerable.Empty<string>();

        public T Data { get; }
    }
}
