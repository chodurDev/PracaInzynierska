using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EpillBox.API.Models
{
    public class Form
    {
        [Key]
        public int IdForm { get; set; }
        public string Name { get; set; }
        public ICollection<Medicine> Medicines { get; set; }

    }
}