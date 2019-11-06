using EpillBox.API.Models;
using Microsoft.EntityFrameworkCore;

namespace EpillBox.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

      
        
        public DbSet<FirstAidKit> FirstAidKits { get; set; }
        
        public DbSet<Medicine> Medicines { get; set; }
        
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<FirstAidKit>()
                .HasOne(fak => fak.Medicine)
                .WithMany(m => m.FirstAidKit);

            modelBuilder.Entity<FirstAidKit>()
                .HasOne(fak => fak.User)
                .WithMany(u => u.FirstAidKit);

            

            modelBuilder.Entity<UserAlergics>()
                            .HasOne(ua => ua.User)
                            .WithMany(u => u.UserAlergics);

            modelBuilder.Entity<UserAlergics>()
                            .HasOne(ua => ua.Alergic)
                            .WithMany(a => a.UserAlergics);



            modelBuilder.Entity<Producer>()
                .HasMany(p => p.Medicines)
                .WithOne(m => m.Producer);

            modelBuilder.Entity<Form>()
                .HasMany(f => f.Medicines)
                .WithOne(m => m.Form);


            
            modelBuilder.Entity<MedicineComposition>()
                .HasOne(mc => mc.Medicine)
                .WithMany(m => m.MedicineCompositions);
                
            modelBuilder.Entity<MedicineComposition>()
                .HasOne(mc => mc.Composition)
                .WithMany(c => c.MedicineCompositions);
                

           
            modelBuilder.Entity<MedicineCategory>()
                .HasOne(mc => mc.Medicine)
                .WithMany(m => m.MedicineCategory);
                
            modelBuilder.Entity<MedicineCategory>()
                .HasOne(mc => mc.Category)
                .WithMany(c => c.MedicineCategories);
                



        }

    }
}