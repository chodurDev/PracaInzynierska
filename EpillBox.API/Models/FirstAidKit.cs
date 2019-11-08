using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EpillBox.API.Models
{
    public class FirstAidKit
    {
       public int FirstAidKitID { get; set; }

       public ICollection<UserFirstAidKit> UserFirstAidKits { get; set; }
        public ICollection<FirstAidKitMedicine> FirstAidKitMedicines { get; set; }

        
    }
}