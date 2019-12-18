using System.Collections.Generic;

namespace EpillBox.API.Models
{
    public class Allergies
    {
        public int AllergiesID { get; set; }
        public string Name { get; set; }
        public ICollection<UsersAllergies> UsersAllergies { get; set; }
    }
}