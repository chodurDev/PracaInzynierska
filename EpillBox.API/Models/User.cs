using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EpillBox.API.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public ICollection<UserFirstAidKit> UserFirstAidKits { get; set; }

       
    }
}