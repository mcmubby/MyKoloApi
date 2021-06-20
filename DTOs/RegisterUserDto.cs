using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MyKoloApi.DTOs
{
    public class RegisterUserDto
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        [MaxLength(11)]
        public string PhoneNumber { get; set; }
    }
}