using Microsoft.AspNetCore.Identity;
using TravelEstates.Data.Abstraction.Helpers;
using TravelEstates.Data.Models.Entities.Base;

namespace TravelEstates.Data.Helpers
{
    public class TravelEstateSingInManager : ITravelEstatesSignInManager
    {
        private readonly SignInManager<User> _signInManager;

        public TravelEstateSingInManager(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<SignInResult> PasswordSignInAsync(User user, string password, bool isPersistant, bool lockoutOnFailure)
        {
            var result = await _signInManager.PasswordSignInAsync(user, password, isPersistant, lockoutOnFailure);

            return result;
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
