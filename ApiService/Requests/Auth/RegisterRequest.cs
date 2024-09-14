using System.ComponentModel.DataAnnotations;

namespace ApiService.Requests.Auth
{
    public class RegisterRequest
    {
        [Required]
        [EmailAddress]
        public string email { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$", ErrorMessage = "Password must be at least 8 characters long and include at least one lowercase letter, one uppercase letter, one digit, and one special character.")]

        public string password { get; set; }
    }
}
