namespace EpillBox.API.Models
{
    public class MedicineComposition
    {
        public int IdMedicine { get; set; }
        public Medicine Medicine { get; set; }
        public int IdComposition { get; set; }
        public Composition Composition { get; set; }
    }
}