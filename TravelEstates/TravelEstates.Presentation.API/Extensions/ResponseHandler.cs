using Microsoft.AspNetCore.Mvc;
using TravelEstates.Business.Models.Enums;
using TravelEstates.Business.Models.Results.Base;

namespace TravelEstates.Presentation.API.Extensions
{
    public static class ResponseHandler
    {
        public static IActionResult HandleResponse<T>(this ControllerBase controller, IResult<T> response)
        {
            switch (response.StatusCode)
            {
                case TravelEstatesStatusCode.NotFound:
                    return controller.NotFound(response.ErrorMessages);

                case TravelEstatesStatusCode.BadRequest:
                    return controller.BadRequest(response.ErrorMessages);

                case TravelEstatesStatusCode.Unauthorized:
                    return controller.Unauthorized(response.ErrorMessages);

                case TravelEstatesStatusCode.Forbidden:
                    return controller.Forbid();

                case TravelEstatesStatusCode.NoContent:
                    return controller.NoContent();

                default:
                    return controller.Ok(response.Data);
            }
        }
    }
}
