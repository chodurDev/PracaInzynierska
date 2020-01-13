using System;
using System.Collections.Generic;

namespace EpillBox.API.Dtos
{
    public class UserMedicinesToViewDto
    {
        public int FirstAidKitMedicineID { get; set; }

       
        public int MedicineID { get; set; }

       
        public int FirstAidKitID { get; set; }
        public string FakName { get; set; }

        public string Name { get; set; }
        public int QuantityInPackage { get; set; }
        

        public DateTime? ExpirationDate { get; set; }
        public bool IsTaken { get; set; }
        public int RemainingQuantity { get; set; }
        public string Form { get; set; }
        public string Producer { get; set; }
        public List<string> ActiveSubstance { get; set; }

        public DateTime FirstServingAt {get; set;}
        public int NumberOfServings { get; set; }
        public int ServingSize { get; set; }
    }
}