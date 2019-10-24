using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EpillBox.API.Models
{
    public class Producer
    {
        [Key]
        public int IdProducer { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public ICollection<Medicine> Medicines { get; set; }
    }
}