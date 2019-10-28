using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EpillBox.API.Models
{
    public class MedicineCategory
    {
        [Key]
        public int IdMedicineCategory { get; set; }

        [ForeignKey("Medicine")]
        public int IdMedicine { get; set; }
        public Medicine Medicine { get; set; }
        [ForeignKey("Category")]
        public int IdCategory { get; set; }
        public Category Category { get; set; }
    }
}