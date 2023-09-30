using Microsoft.AspNetCore.Identity;
using TravelEstates.Data.Models.Entities.Base;

namespace TravelEstates.Data.Abstraction.Helpers
{
    public interface ITravelEstatesSignInManager
    {
        Task<SignInResult> PasswordSignInAsync(User user, string password, bool isPersistent, bool lockoutOnFailure);

        Task SignOutAsync();
    }
}
