using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EpillBox.API.Models
{
    public class Medicine
    {
        [Key]
        public int IdMedicine { get; set; }
        public Producer Producer { get; set; }
        public int Quantity { get; set; }

        public ICollection<MedicineComposition> MedicineCompositions { get; set; }
        public Form Form { get; set; }
        public ICollection<MedicineCategory> MedicineCategory { get; set; }
        public string Effect { get; set; }

        public ICollection<FirstAidKit> FirstAidKit { get; set; }




    }
}