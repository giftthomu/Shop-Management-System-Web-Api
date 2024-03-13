using System.ComponentModel.DataAnnotations;

namespace Shop_Management_WEB_API.DTOs.Users
{
    public class UserDto
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [StringLength(50, ErrorMessage = "First name must be between 1 and 50 characters", MinimumLength = 1)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(50, ErrorMessage = "Last name must be between 1 and 50 characters", MinimumLength = 1)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "User type is required")]
        public string UserType { get; set; }
    }
}
