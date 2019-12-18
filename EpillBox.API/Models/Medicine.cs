using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EpillBox.API.Models
{
    public class Medicine
    {
        public int MedicineID { get; set; }
        public string Name { get; set; }
        public int QuantityInPackage { get; set; }

        public ICollection<FirstAidKitMedicine> FirstAidKitMedicines { get; set; }
        public ICollection<ShoppingBasketMedicine> ShoppingBasketMedicines { get; set; }

        public ICollection<ActiveSubstanceMedicine> ActiveSubstanceMedicines { get; set; }
        
        [ForeignKey("Producer")]
        public int ProducerID { get; set; }
        public Producer Producer { get; set; }

        [ForeignKey("MedicineForm")]
        public int MedicineFormID { get; set; }
        public MedicineForm MedicineForm { get; set; }






    }
}