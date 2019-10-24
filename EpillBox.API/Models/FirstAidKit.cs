using System;

namespace EpillBox.API.Models
{
    public class FirstAidKit
    {
        public int IdUser { get; set; }
        public User User { get; set; }
        public int IdMedicine { get; set; }
        public Medicine Medicine { get; set; }

        public DateTime ExpirationDate { get; set; }
        public bool IsTaken { get; set; }
        public int remainingQuantity { get; set; }
        public bool IsAlergicTo { get; set; }
    }
}