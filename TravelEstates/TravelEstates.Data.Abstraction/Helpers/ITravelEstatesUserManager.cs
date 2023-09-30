using Microsoft.AspNetCore.Identity;
using TravelEstates.Data.Models.Entities.Base;

namespace TravelEstates.Data.Abstraction.Helpers
{
    public interface ITravelEstatesUserManager
    {
        Task CreateAdminAsync(User user, string password);

        Task CreateUserAsync(User user, string password);

        Task<User> FindByEmailAsync(string email);

        Task<User> FindUserByIdAsync(string userId);

        Task<IEnumerable<string>> GetRolesAsync(User user);

        Task<string> GenerateConfirmEmailTokenAsync(User user);

        Task<IdentityResult> ConfirmEmailAsync(User user, string token);

        Task<string> GenerateResetPasswordTokenAsync(User user);

        Task<IdentityResult> ResetPasswordAsync(User user, string token, string newPassword, string confirmPassword);

        Task<bool> IsValidTokenAsync(User user, string tokenProvider, string purpose, string token);
    }
}
