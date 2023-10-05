using TravelEstates.Business.Models.DTOs.RentPropertyDTOs;
using TravelEstates.Business.Models.Results.Base;

namespace TravelEstates.Business.Abstraction.Services
{
    public interface IRentPropertyService
    {
        public Task<IResult<ICollection<RentPropertyResultDTO>>> GetAllAsync();

        public Task<IResult<RentPropertyResultDTO>> GetByIdAsync(string id);

        public Task<IResult<RentPropertyResultDTO>> AddAsync(RentPropertyCreateDTO rentPropertyCreateDTO);

        public Task<IResult<RentPropertyResultDTO>> UpdateAsync(string id, RentPropertyUpdateDTO UserUpdateDTO);

        public Task<IResult<RentPropertyDeleteDTO>> DeleteAsync(string id);
    }
}
