using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EpillBox.API.Models
{
    public class Medicine
    {
        [Key]
        public int IdMedicine { get; set; }
        [ForeignKey("IdProducer")]
        public int IdProducer { get; set; }

        public Producer Producer { get; set; }
        public int Quantity { get; set; }

        public ICollection<MedicineComposition> MedicineCompositions { get; set; }

        [ForeignKey("IdForm")]
        public int IdForm { get; set; }
        public Form Form { get; set; }
        public ICollection<MedicineCategory> MedicineCategory { get; set; }
        public string Effect { get; set; }

        public ICollection<FirstAidKit> FirstAidKit { get; set; }




    }
}