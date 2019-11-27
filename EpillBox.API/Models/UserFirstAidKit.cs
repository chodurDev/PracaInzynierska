using System.ComponentModel.DataAnnotations.Schema;

namespace EpillBox.API.Models
{
    public class UserFirstAidKit
    {
        public int UserFirstAidKitID { get; set; }
        [ForeignKey("User")]
        public int UserID { get; set; }

        [ForeignKey("FirstAidKit")]
        public int FirstAidKitID { get; set; }

        public User User { get; set; }
        public FirstAidKit FirstAidKit { get; set; }
        public string Name { get; set; }
    }
}