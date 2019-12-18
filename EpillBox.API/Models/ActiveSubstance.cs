using System.Collections.Generic;

namespace EpillBox.API.Models
{
    public class ActiveSubstance
    {
        public int ActiveSubstanceID { get; set; }
        public string Name { get; set; }
        public ICollection<ActiveSubstanceMedicine> ActiveSubstanceMedicines { get; set; }
    }
}