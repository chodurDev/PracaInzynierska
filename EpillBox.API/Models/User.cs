using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EpillBox.API.Models
{
    public class User
    {
        [Key]
        public int IdUser { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public ICollection<UserAlergics> UserAlergics { get; set; }

        public ICollection<FirstAidKit> FirstAidKit { get; set; }
    }
}