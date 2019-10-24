using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EpillBox.API.Models
{
    public class FirstAidKit
    {

        [ForeignKey("User")]
        public int IdUser { get; set; }
        public User User { get; set; }

        [ForeignKey("Medicine")]
        public int IdMedicine { get; set; }
        public Medicine Medicine { get; set; }

        public DateTime ExpirationDate { get; set; }
        public bool IsTaken { get; set; }
        public int remainingQuantity { get; set; }
        public bool IsAlergicTo { get; set; }
    }
}