using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EpillBox.API.Models
{
    public class MedicineComposition
    {
        [Key]
        public int IdMedicineComposition { get; set; }

        [ForeignKey("Medicine")]
        public int IdMedicine { get; set; }
        public Medicine Medicine { get; set; }
        
        [ForeignKey("Composition")]
        public int IdComposition { get; set; }
        public Composition Composition { get; set; }
    }
}