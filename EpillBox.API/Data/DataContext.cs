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

    }
}