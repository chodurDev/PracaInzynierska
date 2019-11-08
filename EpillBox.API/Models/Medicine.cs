using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EpillBox.API.Models
{
    public class Medicine
    {
        public int MedicineID { get; set; }
        public string Name { get; set; }

        public ICollection<FirstAidKitMedicine> FirstAidKitMedicines { get; set; }
       




    }
}