using System.ComponentModel.DataAnnotations;

namespace ConversorBack.DTOs
{
    public class AuthDto
    {
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
