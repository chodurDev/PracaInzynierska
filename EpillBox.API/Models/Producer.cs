using System.Collections.Generic;

namespace EpillBox.API.Models
{
    public class Producer
    {
        public int IdProducer { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public ICollection<Medicine> Medicines { get; set; }
    }
}