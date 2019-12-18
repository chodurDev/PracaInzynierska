using System.ComponentModel.DataAnnotations.Schema;

namespace EpillBox.API.Models
{
    public class ActiveSubstanceMedicine
    {
        public int ActiveSubstanceMedicineID { get; set; }
        [ForeignKey("ActiveSubstance")]
        public int ActiveSubstanceID { get; set; }
        public ActiveSubstance ActiveSubstance { get; set; }

        [ForeignKey("Medicine")]
        public int MedicineID { get; set; }
        public Medicine Medicine { get; set; }
    }
}