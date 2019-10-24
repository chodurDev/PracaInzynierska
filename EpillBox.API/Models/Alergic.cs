using System.ComponentModel.DataAnnotations;

namespace EpillBox.API.Models
{
    public class Alergic
    {
        [Key]
        public int IdAlergic { get; set; }
        public User User { get; set; }
        public string substanceName { get; set; }
    }
}