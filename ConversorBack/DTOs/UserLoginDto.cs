using System.ComponentModel.DataAnnotations;

namespace ConversorBack.DTOs
{
    public class UserLoginDto
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
