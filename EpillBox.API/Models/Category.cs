using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EpillBox.API.Models
{
    public class Category
    {
        [Key]
        public int IdCategory { get; set; }
        public string Name { get; set; }

        public ICollection<MedicineCategory> MedicineCategories { get; set; }
    }
}