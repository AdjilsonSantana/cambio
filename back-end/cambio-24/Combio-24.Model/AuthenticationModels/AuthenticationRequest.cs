using System.ComponentModel.DataAnnotations;

namespace Cambio_24.Models.AuthenticationModels
{
    public class AuthenticationRequest
    {
       
        public string Email { get; set; }
        public string Username { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}
