using Microsoft.AspNetCore.Mvc;
using TravelEstates.Business.Models.Enums;
using TravelEstates.Business.Models.Results.Base;

namespace TravelEstates.Presentation.API.Extensions
{
    public static class ResponseHandler
    {
        public static IActionResult HandleResponse<T>(this ControllerBase controller, IResult<T> response)
        {
            if (response.StatusCode == TravelEstatesStatusCode.NotFound)
            {
                return controller.NotFound(response.ErrorMessages);
            }
            else if (response.StatusCode == TravelEstatesStatusCode.BadRequest)
            {
                return controller.BadRequest(response.ErrorMessages);
            }
            else if (response.StatusCode == TravelEstatesStatusCode.Unauthorized)
            {
                return controller.Unauthorized(response.ErrorMessages);
            }
            else if (response.StatusCode == TravelEstatesStatusCode.Forbidden)
            {
                return controller.Forbid();
            }
            else if (response.StatusCode == TravelEstatesStatusCode.OK)
            {
                return controller.Ok(response.Data);
            }
            else if (response.StatusCode == TravelEstatesStatusCode.NoContent)
            {
                return controller.NoContent();
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
