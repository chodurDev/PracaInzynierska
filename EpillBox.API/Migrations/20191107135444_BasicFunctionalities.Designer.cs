﻿// <auto-generated />
using EpillBox.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EpillBox.API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20191107135444_BasicFunctionalities")]
    partial class BasicFunctionalities
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("EpillBox.API.Models.FirstAidKit", b =>
                {
                    b.Property<int>("FirstAidKitID")
                        .ValueGeneratedOnAdd();

                    b.HasKey("FirstAidKitID");

                    b.ToTable("FirstAidKits");
                });

            modelBuilder.Entity("EpillBox.API.Models.FirstAidKitMedicine", b =>
                {
                    b.Property<int>("FirstAidKitMedicineID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("FirstAidKitID");

                    b.Property<int>("MedicineID");

                    b.HasKey("FirstAidKitMedicineID");

                    b.HasIndex("FirstAidKitID");

                    b.HasIndex("MedicineID");

                    b.ToTable("FirstAidKitMedicines");
                });

            modelBuilder.Entity("EpillBox.API.Models.Medicine", b =>
                {
                    b.Property<int>("MedicineID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("MedicineID");

                    b.ToTable("Medicines");
                });

            modelBuilder.Entity("EpillBox.API.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Login");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<string>("Surname");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EpillBox.API.Models.UserFirstAidKit", b =>
                {
                    b.Property<int>("UserFirstAidKitID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("FirstAidKitID");

                    b.Property<int>("UserID");

                    b.HasKey("UserFirstAidKitID");

                    b.HasIndex("FirstAidKitID");

                    b.HasIndex("UserID");

                    b.ToTable("UserFirstAidKits");
                });

            modelBuilder.Entity("EpillBox.API.Models.FirstAidKitMedicine", b =>
                {
                    b.HasOne("EpillBox.API.Models.FirstAidKit", "FirstAidKit")
                        .WithMany("FirstAidKitMedicines")
                        .HasForeignKey("FirstAidKitID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EpillBox.API.Models.Medicine", "Medicine")
                        .WithMany("FirstAidKitMedicines")
                        .HasForeignKey("MedicineID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EpillBox.API.Models.UserFirstAidKit", b =>
                {
                    b.HasOne("EpillBox.API.Models.FirstAidKit", "FirstAidKit")
                        .WithMany("UserFirstAidKits")
                        .HasForeignKey("FirstAidKitID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EpillBox.API.Models.User", "User")
                        .WithMany("UserFirstAidKits")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
