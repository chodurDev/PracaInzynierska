namespace EpillBox.API.Models
{
    public class MedicineCategory
    {
        
        public int IdMedicine { get; set; }
        public Medicine Medicine { get; set; }
        public int IdCategory { get; set; }
        public Category Category { get; set; }
    }
}