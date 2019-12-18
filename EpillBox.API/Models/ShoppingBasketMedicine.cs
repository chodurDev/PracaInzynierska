using System.ComponentModel.DataAnnotations.Schema;

namespace EpillBox.API.Models
{
    public class ShoppingBasketMedicine
    {
        public int ShoppingBasketMedicineID { get; set; }
        [ForeignKey("Medicine")]
        public int MedicineID { get; set; }
        public Medicine Medicine { get; set; }

        [ForeignKey("ShoppingBasket")]
        public int ShoppingBasketID { get; set; }
        public ShoppingBasket ShoppingBasket { get; set; }
    }
}