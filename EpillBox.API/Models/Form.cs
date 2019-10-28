using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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