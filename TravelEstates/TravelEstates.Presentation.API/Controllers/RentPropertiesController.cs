using Microsoft.AspNetCore.Mvc;
using TravelEstates.Business.Abstraction.Services;
using TravelEstates.Business.Models.DTOs.RentPropertyDTOs;
using TravelEstates.Business.Models.DTOs.UserDTOs;
using TravelEstates.Presentation.API.Extensions;

namespace TravelEstates.Presentation.API.Controllers
{
    [Route("api/rentproperties")]
    [ApiController]
    public class RentPropertiesController : ControllerBase
    {
        public readonly IRentPropertyService _rentPropertyService;

        public RentPropertiesController(IRentPropertyService rentPropertyService)
        {
            _rentPropertyService = rentPropertyService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _rentPropertyService.GetAllAsync();

            return this.HandleResponse(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] string id)
        {
            var result = await _rentPropertyService.GetByIdAsync(id);

            return this.HandleResponse(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] RentPropertyCreateDTO rentPropertyCreateDTO)
        {
            var result = await _rentPropertyService.AddAsync(rentPropertyCreateDTO);

            return this.HandleResponse(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(string id, [FromBody] RentPropertyUpdateDTO rentPropertyUpdateDTO)
        {
            var result = await _rentPropertyService.UpdateAsync(id, rentPropertyUpdateDTO);

            return this.HandleResponse(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var result = await _rentPropertyService.DeleteAsync(id);

            return this.HandleResponse(result);
        }
    }
}
