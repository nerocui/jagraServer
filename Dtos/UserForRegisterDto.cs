using System.ComponentModel.DataAnnotations;

namespace server.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "You must specify password between 8 and 50 characters")]
        public string Password { get; set; }
    }
}
