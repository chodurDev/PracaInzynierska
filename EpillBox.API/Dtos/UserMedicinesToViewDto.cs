using System;

namespace EpillBox.API.Dtos
{
    public class UserMedicinesToViewDto
    {
        public int FirstAidKitMedicineID { get; set; }

       
        public int MedicineID { get; set; }

       
        public int FirstAidKitID { get; set; }

        public string Name { get; set; }
        public int QuantityInPackage { get; set; }
        

        public DateTime ExpirationDate { get; set; }
        public bool IsTaken { get; set; }
        public int RemainingQuantity { get; set; }
    }
}