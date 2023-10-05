using AutoMapper;
using TravelEstates.Business.Abstraction.Factories;
using TravelEstates.Business.Abstraction.Services;
using TravelEstates.Business.Models.DTOs.UserDTOs;
using TravelEstates.Business.Models.Results.Base;
using TravelEstates.Business.Models.Utilities;
using TravelEstates.Data.Abstraction.Repositories;
using TravelEstates.Data.Models.Entities.Base;

namespace TravelEstates.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IResultFactory _resultFactory;
        private readonly IBookingRepository _bookingRepository;
        private readonly IUserRepository _userRepository;

        public UserService(
            IMapper mapper,
            IResultFactory resultFactory,
            IBookingRepository bookingRepository,
            IUserRepository userRepository)
        {
            _mapper = mapper;
            _resultFactory = resultFactory;
            _bookingRepository = bookingRepository;
            _userRepository = userRepository;
        }

        public async Task<IResult<ICollection<UserResultDTO>>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync(u => true);

            var userResultDTOs = _mapper.Map<ICollection<UserResultDTO>>(users);

            if (!userResultDTOs.Any())
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<ICollection<UserResultDTO>>(UserDTOMessages.UsersNotFound);
                return notFoundResult;
            }

            var okResult = _resultFactory.GetOkResult(userResultDTOs);

            return okResult;
        }

        public async Task<IResult<UserResultDTO>> GetByIdAsync(string id)
        {
            var user = await _userRepository.FindEntityAsync(u => u.Id == id);

            if (user == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<UserResultDTO>(UserDTOMessages.UserNotFound);

                return notFoundResult;
            }

            var userResultDTO = _mapper.Map<UserResultDTO>(user);
            var okResult = _resultFactory.GetOkResult(userResultDTO);

            return okResult;
        }

        public async Task<IResult<UserResultDTO>> AddAsync(UserRegistrationDTO userRegistrationDTO)
        {
            var userEntity = _mapper.Map<User>(userRegistrationDTO);

            await _userRepository.AddAsync(userEntity);

            var createdResultDTO = _mapper.Map<UserResultDTO>(userEntity);
            var createdResult = _resultFactory.GetCreatedResult(createdResultDTO);

            return createdResult;
        }

        public async Task<IResult<UserResultDTO>> UpdateAsync(string id, UserUpdateDTO UserUpdateDTO)
        {
            var existingUser = await _userRepository.FindEntityAsync(u => u.Id == id);

            if (existingUser == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<UserResultDTO>(UserDTOMessages.UserNotFound);
                return notFoundResult;
            }

            _mapper.Map(UserUpdateDTO, existingUser);

            await _userRepository.UpdateAsync(existingUser);

            var updatedResultDTO = _mapper.Map<UserResultDTO>(existingUser);
            var updatedResult = _resultFactory.GetOkResult(updatedResultDTO);

            return updatedResult;
        }

        public async Task<IResult<UserDeleteDTO>> DeleteAsync(string id)
        {
            var existingUser = await _userRepository.FindEntityAsync(u => u.Id == id);

            if (existingUser == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<UserDeleteDTO>(BookingDTOMessages.BookingNotFound);
                return notFoundResult;
            }

            var userBookings = await _bookingRepository.GetAllAsync(b => b.UserId == existingUser.Id);

            if (userBookings.Any())
            {
                await _bookingRepository.DeleteRangeAsync(userBookings);
            }

            await _userRepository.DeleteAsync(existingUser);

            var okResult = _resultFactory.GetOkResult<UserDeleteDTO>();

            return okResult;
        }
    }
}
