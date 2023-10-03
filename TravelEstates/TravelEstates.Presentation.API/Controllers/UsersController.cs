using Microsoft.AspNetCore.Mvc;
using TravelEstates.Business.Abstraction.Services;
using TravelEstates.Business.Models.DTOs.UserDTOs;
using TravelEstates.Presentation.API.Extensions;

namespace TravelEstates.Presentation.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _userService.GetAllAsync();

            return this.HandleResponse(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] string id)
        {
            var result = await _userService.GetByIdAsync(id);

            return this.HandleResponse(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] UserRegistrationDTO userRegistrationDTO)
        {
            var result = await _userService.AddAsync(userRegistrationDTO);

            return this.HandleResponse(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(string id, [FromBody] UserUpdateDTO userUpdateDTO)
        {
            var result = await _userService.UpdateAsync(id, userUpdateDTO);

            return this.HandleResponse(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var result = await _userService.DeleteAsync(id);

            return this.HandleResponse(result);
        }
    }
}
