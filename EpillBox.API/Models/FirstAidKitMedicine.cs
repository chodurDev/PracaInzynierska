using System;
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

        public DateTime? ExpirationDate { get; set; }
        public bool IsTaken { get; set; }
        public int RemainingQuantity { get; set; }
       
        public DateTime FirstServingAt {get; set;}
        public int NumberOfServings { get; set; }
        public int ServingSize { get; set; }
       
    }
}