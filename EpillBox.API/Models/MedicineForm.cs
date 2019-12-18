using System.Collections.Generic;

namespace EpillBox.API.Models
{
    public class MedicineForm
    {
        public int MedicineFormID { get; set; }
        public string FormName { get; set; }
        public ICollection<Medicine> Medicines { get; set; }
    }
}