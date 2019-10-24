using System.ComponentModel.DataAnnotations;

namespace EpillBox.API.Models
{
    public class Alergics
    {
        [Key]
        public int IdAlergics { get; set; }
        public User User { get; set; }
        public string substanceName { get; set; }
    }
}