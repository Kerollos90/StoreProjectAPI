using System.ComponentModel.DataAnnotations;

namespace Store.Service.Services.UserServices.Dtos
{
    public class RegisterDto
    {
        [Required]
        public string DisplayName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "password is required")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z\d]).{6,}$",
        ErrorMessage = "Password must be at least 6 characters long, with one uppercase letter, one lowercase letter, one digit, and one special character.")]
        public string Password { get; set; }



    }
}