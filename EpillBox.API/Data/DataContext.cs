using EpillBox.API.Models;
using Microsoft.EntityFrameworkCore;

namespace EpillBox.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Alergic> Alergics { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Composition> Compositions { get; set; }
        public DbSet<FirstAidKit> FirstAidKits { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<MedicineCategory> MedicineCategories { get; set; }
        public DbSet<MedicineComposition> MedicineCompositions { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //konfiguracja wiele do wielu user-> firstAidKit <-medicine
            modelBuilder.Entity<FirstAidKit>().HasKey(fak => new { fak.IdMedicine, fak.IdUser });
            modelBuilder.Entity<FirstAidKit>()
                .HasOne(fak => fak.Medicine)
                .WithMany(m => m.FirstAidKit)
                .HasForeignKey(fak => fak.IdMedicine);
            modelBuilder.Entity<FirstAidKit>()
                .HasOne(fak => fak.User)
                .WithMany(u => u.FirstAidKit)
                .HasForeignKey(fak => fak.IdUser);
            /////////////////


            modelBuilder.Entity<User>()
                .HasMany(u => u.Alergics)
                .WithOne(a => a.User);

            modelBuilder.Entity<Producer>()
                .HasMany(p => p.Medicines)
                .WithOne(m => m.Producer);

            modelBuilder.Entity<Form>()
                .HasMany(f => f.Medicines)
                .WithOne(m => m.Form);


            modelBuilder.Entity<MedicineComposition>().HasKey(mc => new { mc.IdMedicine, mc.IdComposition });
            modelBuilder.Entity<MedicineComposition>()
                .HasOne(mc => mc.Medicine)
                .WithMany(m => m.MedicineCompositions)
                .HasForeignKey(mc => mc.IdMedicine);
            modelBuilder.Entity<MedicineComposition>()
                .HasOne(mc => mc.Composition)
                .WithMany(c => c.MedicineCompositions)
                .HasForeignKey(mc => mc.IdComposition);

            modelBuilder.Entity<MedicineCategory>().HasKey(mc => new { mc.IdMedicine, mc.IdCategory });
            modelBuilder.Entity<MedicineCategory>()
                .HasOne(mc => mc.Medicine)
                .WithMany(m => m.MedicineCategory)
                .HasForeignKey(mc => mc.IdMedicine);
            modelBuilder.Entity<MedicineCategory>()
                .HasOne(mc => mc.Category)
                .WithMany(c => c.MedicineCategories)
                .HasForeignKey(mc => mc.IdCategory);



        }

    }
}