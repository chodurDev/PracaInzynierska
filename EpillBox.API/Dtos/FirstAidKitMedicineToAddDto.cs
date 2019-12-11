using System;
using System.ComponentModel.DataAnnotations;

namespace EpillBox.API.Dtos
{
    public class FirstAidKitMedicineToAddDto
    {
        public int? FirstAidKitMedicineID { get; set; }

        public int? MedicineID { get; set; }

        public int? FirstAidKitID { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public bool? IsTaken { get; set; }
        public int? RemainingQuantity { get; set; }
    }
}