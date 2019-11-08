using System.ComponentModel.DataAnnotations.Schema;

namespace EpillBox.API.Models
{
    public class FirstAidKitMedicine
    {
        public int FirstAidKitMedicineID { get; set; }

        [ForeignKey("Medicine")]
        public int MedicineID { get; set; }

        [ForeignKey("FirstAidKit")]
        public int FirstAidKitID { get; set; }

        public Medicine Medicine { get; set; }
        public FirstAidKit FirstAidKit { get; set; }
    }
}