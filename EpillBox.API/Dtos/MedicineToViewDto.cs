using System.Collections.Generic;

namespace EpillBox.API.Dtos
{
    public class MedicineToViewDto
    {
         public int MedicineID { get; set; }
        public string Name { get; set; }
        public int QuantityInPackage { get; set; }

        public string Form { get; set; }
        public string Producer { get; set; }
        public List<string> ActiveSubstance { get; set; }
    }
}