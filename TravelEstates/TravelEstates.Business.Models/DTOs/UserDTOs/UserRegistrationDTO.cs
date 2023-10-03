using System.ComponentModel.DataAnnotations;
using TravelEstates.Business.Models.Utilities;

namespace TravelEstates.Business.Models.DTOs.UserDTOs
{
    public class UserRegistrationDTO
    {
        [Required(ErrorMessage = UserDTOMessages.EmptyEmail)]
        [EmailAddress(ErrorMessage = UserDTOMessages.InvalidEmail)]
        [MaxLength(UserDTOConstants.MaxLengthEmail, ErrorMessage = UserDTOMessages.InvalidEmail)]
        [RegularExpression(UserDTOConstants.EmailRegex, ErrorMessage = UserDTOMessages.InvalidEmail)]
        public string Email { get; set; }

        [Required(ErrorMessage = UserDTOMessages.EmptyPassword)]
        [DataType(DataType.Password)]
        [StringLength(UserDTOConstants.MaxLengthPassword, MinimumLength = UserDTOConstants.MinLengthPassword, ErrorMessage = UserDTOMessages.InvalidPasswordLength)]
        [RegularExpression(UserDTOConstants.PasswordRegex, ErrorMessage = UserDTOMessages.WeakPassword)]
        public string Password { get; set; }

        [Required(ErrorMessage = UserDTOMessages.EmptyConfirmPassword)]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = UserDTOMessages.PasswordsNoMatch)]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = UserDTOMessages.EmptyFirstName)]
        [StringLength(UserDTOConstants.MaxLengthFirstName, ErrorMessage = UserDTOMessages.InvalidFirstNameLength)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = UserDTOMessages.EmptyLastName)]
        [StringLength(UserDTOConstants.MaxLengthLastName, ErrorMessage = UserDTOMessages.InvalidLastNameLength)]
        public string LastName { get; set; }
    }
}
