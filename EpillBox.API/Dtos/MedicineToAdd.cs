namespace EpillBox.API.Dtos
{
    public class MedicineToAdd
    {
       
        public string Name { get; set; }
        public int QuantityInPackage { get; set; }

        public string Producer { get; set; }

        public int Form { get; set; }
        public string ActiveSubstance { get; set; }

    }
}