using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EpillBox.API.Models
{
    public class UserAlergics
    {
        [Key]
        public int IdUserAlergics { get; set; }
        
        [ForeignKey("User")]
        public int IdUser { get; set; }
        public User User { get; set; }

        [ForeignKey("Alergic")]
        public int IdAlergic { get; set; }
        public Alergic Alergic { get; set; }
    }
}