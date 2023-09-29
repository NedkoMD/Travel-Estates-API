using Microsoft.AspNetCore.Identity;

namespace TravelEstates.Data.Models.Entities.Base
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool Verified { get; set; }

        // Navigation property for bookings
        public ICollection<Booking> Bookings { get; set; }

        // Navigation property for tokens
        public ICollection<Token> Tokens { get; set; }
    }
}
