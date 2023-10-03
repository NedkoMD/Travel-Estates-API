using TravelEstates.Business.Models.DTOs.UserDTOs;
using TravelEstates.Business.Models.Results.Base;

namespace TravelEstates.Business.Abstraction.Services
{
    public interface IUserService
    {
        Task<IResult<IEnumerable<UserResultDTO>>> GetAllAsync();

        Task<IResult<UserResultDTO>> GetByIdAsync(string id);

        Task<IResult<UserResultDTO>> AddAsync(UserRegistrationDTO userRegistrationDTO);

        Task<IResult<UserResultDTO>> UpdateAsync(string id, UserUpdateDTO UserUpdateDTO);

        Task<IResult<UserDeleteDTO>> DeleteAsync(string id);
    }
}
