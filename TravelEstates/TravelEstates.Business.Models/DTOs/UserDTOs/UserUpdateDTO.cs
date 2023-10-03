using System.ComponentModel.DataAnnotations;
using TravelEstates.Business.Models.Utilities;

namespace TravelEstates.Business.Models.DTOs.UserDTOs
{
    public class UserUpdateDTO
    {
        [Required(ErrorMessage = UserDTOMessages.EmptyEmail)]
        [EmailAddress(ErrorMessage = UserDTOMessages.InvalidEmail)]
        [MaxLength(UserDTOConstants.MaxLengthEmail, ErrorMessage = UserDTOMessages.InvalidEmail)]
        [RegularExpression(UserDTOConstants.EmailRegex, ErrorMessage = UserDTOMessages.InvalidEmail)]
        public string Email { get; set; }

        [Required(ErrorMessage = UserDTOMessages.EmptyFirstName)]
        [StringLength(UserDTOConstants.MaxLengthFirstName, ErrorMessage = UserDTOMessages.InvalidFirstNameLength)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = UserDTOMessages.EmptyLastName)]
        [StringLength(UserDTOConstants.MaxLengthLastName, ErrorMessage = UserDTOMessages.InvalidLastNameLength)]
        public string LastName { get; set; }
    }
}
