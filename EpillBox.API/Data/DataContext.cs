using EpillBox.API.Models;
using Microsoft.EntityFrameworkCore;

namespace EpillBox.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

      
        
        public DbSet<FirstAidKit> FirstAidKits { get; set; }
         public DbSet<FirstAidKitMedicine> FirstAidKitMedicines { get; set; }
         public DbSet<UserFirstAidKit> UserFirstAidKits { get; set; }

        
        public DbSet<Medicine> Medicines { get; set; }
        
        public DbSet<User> Users { get; set; }
        public DbSet<ActiveSubstance> ActiveSubstances { get; set; }
        public DbSet<ActiveSubstanceMedicine> ActiveSubstanceMedicines { get; set; }
        public DbSet<Allergies> Allergies { get; set; }
        public DbSet<MedicineForm> MedicineForms { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<ShoppingBasket> ShoppingBaskets { get; set; }
        public DbSet<ShoppingBasketMedicine> ShoppingBasketMedicines { get; set; }
        public DbSet<UsersAllergies> UsersAllergies { get; set; }

    }
}