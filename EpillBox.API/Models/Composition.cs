using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EpillBox.API.Models
{
    public class Composition
    {
        [Key]
        public int IdComposition { get; set; }
        public string Name { get; set; }

        public ICollection<MedicineComposition> MedicineCompositions { get; set; }
    }
}