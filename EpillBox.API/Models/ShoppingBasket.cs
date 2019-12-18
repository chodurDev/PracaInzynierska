using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EpillBox.API.Models
{
    public class ShoppingBasket
    {
        public int ShoppingBasketID { get; set; }
        
        [ForeignKey("User")]
        public int UserID { get; set; }
        public User User { get; set; }
        public ICollection<ShoppingBasketMedicine> ShoppingBasketMedicines { get; set; }
    }
}