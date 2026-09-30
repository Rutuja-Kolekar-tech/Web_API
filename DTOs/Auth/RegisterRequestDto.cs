using System.ComponentModel.DataAnnotations;

namespace Web_API_Project.DTOs.Auth
{
    public class RegisterRequestDto
    {
        [Required]
        public string Username { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        [MinLength(4)]
        public string Password { get; set; } = string.Empty;
    }
}
