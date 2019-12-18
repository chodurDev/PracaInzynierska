using System.Collections.Generic;

namespace EpillBox.API.Models
{
    public class Producer
    {
        public int ProducerID { get; set; }
        public string Name { get; set; }
         public ICollection<Medicine> Medicines { get; set; }
    }
}