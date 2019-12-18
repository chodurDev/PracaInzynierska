using System.ComponentModel.DataAnnotations.Schema;

namespace EpillBox.API.Models
{
    public class UsersAllergies
    {
        public int UsersAllergiesID { get; set; }
        [ForeignKey("Allergies")]
        public int AllergiesID { get; set; }
        public Allergies Allergies { get; set; }
        [ForeignKey("User")]
        public int UserID { get; set; }
        public User User { get; set; }
    }
}