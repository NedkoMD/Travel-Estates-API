using TravelEstates.Business.Models.Enums;
using TravelEstates.Business.Models.Results.Base;

namespace TravelEstates.Business.Models.Results
{
    public class OkResult<T> : IResult<T>
    {
        public OkResult(T data)
        {
            Data = data;
        }

        public TravelEstatesStatusCode StatusCode => TravelEstatesStatusCode.OK;
        public IEnumerable<string> ErrorMessages => Enumerable.Empty<string>();
        public T Data { get; }
    }
}
