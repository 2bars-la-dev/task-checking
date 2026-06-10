using System.ComponentModel.DataAnnotations;

namespace TaskApp.DTOs
{
    public class LoginRequestDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }

    public class LoginResponseDTO
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }
    }
}
