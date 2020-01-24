using System.ComponentModel.DataAnnotations;

namespace EpillBox.API.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Surname { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 8, ErrorMessage = "Hasło musi skłądać się minimum z 8 znaków")]
        public string Password { get; set; }
    }
}