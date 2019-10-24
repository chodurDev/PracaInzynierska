using System.Collections.Generic;

namespace EpillBox.API.Models
{
    public class Composition
    {
        public int IdComposition { get; set; }
        public string Name { get; set; }

        public ICollection<MedicineComposition> MedicineCompositions { get; set; }
    }
}