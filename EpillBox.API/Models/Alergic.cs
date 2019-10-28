using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EpillBox.API.Models
{
    public class Alergic
    {
        [Key]
        public int IdAlergic { get; set; }
        
        public string substanceName { get; set; }
        public ICollection<UserAlergics> UserAlergics { get; set; }
    }
}