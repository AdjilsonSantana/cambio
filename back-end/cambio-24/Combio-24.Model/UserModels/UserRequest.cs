using System.ComponentModel.DataAnnotations;

namespace Cambio_24.Models.UserModels
{
    public class UserRequest
    {
        public long Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
        public string Avatar { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
    }
}
