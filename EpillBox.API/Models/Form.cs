using System.Collections.Generic;

namespace EpillBox.API.Models
{
    public class Form
    {
        public int IdForm { get; set; }
        public string Name { get; set; }
        public ICollection<Medicine> Medicines { get; set; }

    }
}