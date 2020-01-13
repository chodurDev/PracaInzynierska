﻿// <auto-generated />
using System;
using EpillBox.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EpillBox.API.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("EpillBox.API.Models.ActiveSubstance", b =>
                {
                    b.Property<int>("ActiveSubstanceID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ActiveSubstanceID");

                    b.ToTable("ActiveSubstances");
                });

            modelBuilder.Entity("EpillBox.API.Models.ActiveSubstanceMedicine", b =>
                {
                    b.Property<int>("ActiveSubstanceMedicineID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ActiveSubstanceID");

                    b.Property<int>("MedicineID");

                    b.HasKey("ActiveSubstanceMedicineID");

                    b.HasIndex("ActiveSubstanceID");

                    b.HasIndex("MedicineID");

                    b.ToTable("ActiveSubstanceMedicines");
                });

            modelBuilder.Entity("EpillBox.API.Models.Allergies", b =>
                {
                    b.Property<int>("AllergiesID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("AllergiesID");

                    b.ToTable("Allergies");
                });

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

                    b.Property<DateTime?>("ExpirationDate");

                    b.Property<int>("FirstAidKitID");

                    b.Property<DateTime>("FirstServingAt");

                    b.Property<bool>("IsTaken");

                    b.Property<int>("MedicineID");

                    b.Property<int>("NumberOfServings");

                    b.Property<int>("RemainingQuantity");

                    b.Property<int>("ServingSize");

                    b.HasKey("FirstAidKitMedicineID");

                    b.HasIndex("FirstAidKitID");

                    b.HasIndex("MedicineID");

                    b.ToTable("FirstAidKitMedicines");
                });

            modelBuilder.Entity("EpillBox.API.Models.Medicine", b =>
                {
                    b.Property<int>("MedicineID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MedicineFormID");

                    b.Property<string>("Name");

                    b.Property<int>("ProducerID");

                    b.Property<int>("QuantityInPackage");

                    b.HasKey("MedicineID");

                    b.HasIndex("MedicineFormID");

                    b.HasIndex("ProducerID");

                    b.ToTable("Medicines");
                });

            modelBuilder.Entity("EpillBox.API.Models.MedicineForm", b =>
                {
                    b.Property<int>("MedicineFormID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FormName");

                    b.HasKey("MedicineFormID");

                    b.ToTable("MedicineForms");
                });

            modelBuilder.Entity("EpillBox.API.Models.Producer", b =>
                {
                    b.Property<int>("ProducerID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ProducerID");

                    b.ToTable("Producers");
                });

            modelBuilder.Entity("EpillBox.API.Models.ShoppingBasket", b =>
                {
                    b.Property<int>("ShoppingBasketID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("UserID");

                    b.HasKey("ShoppingBasketID");

                    b.HasIndex("UserID")
                        .IsUnique();

                    b.ToTable("ShoppingBaskets");
                });

            modelBuilder.Entity("EpillBox.API.Models.ShoppingBasketMedicine", b =>
                {
                    b.Property<int>("ShoppingBasketMedicineID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MedicineID");

                    b.Property<int>("ShoppingBasketID");

                    b.HasKey("ShoppingBasketMedicineID");

                    b.HasIndex("MedicineID");

                    b.HasIndex("ShoppingBasketID");

                    b.ToTable("ShoppingBasketMedicines");
                });

            modelBuilder.Entity("EpillBox.API.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<string>("Surname");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EpillBox.API.Models.UserFirstAidKit", b =>
                {
                    b.Property<int>("UserFirstAidKitID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("FirstAidKitID");

                    b.Property<string>("Name");

                    b.Property<int>("UserID");

                    b.HasKey("UserFirstAidKitID");

                    b.HasIndex("FirstAidKitID");

                    b.HasIndex("UserID");

                    b.ToTable("UserFirstAidKits");
                });

            modelBuilder.Entity("EpillBox.API.Models.UsersAllergies", b =>
                {
                    b.Property<int>("UsersAllergiesID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AllergiesID");

                    b.Property<int>("UserID");

                    b.HasKey("UsersAllergiesID");

                    b.HasIndex("AllergiesID");

                    b.HasIndex("UserID");

                    b.ToTable("UsersAllergies");
                });

            modelBuilder.Entity("EpillBox.API.Models.ActiveSubstanceMedicine", b =>
                {
                    b.HasOne("EpillBox.API.Models.ActiveSubstance", "ActiveSubstance")
                        .WithMany("ActiveSubstanceMedicines")
                        .HasForeignKey("ActiveSubstanceID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EpillBox.API.Models.Medicine", "Medicine")
                        .WithMany("ActiveSubstanceMedicines")
                        .HasForeignKey("MedicineID")
                        .OnDelete(DeleteBehavior.Cascade);
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

            modelBuilder.Entity("EpillBox.API.Models.Medicine", b =>
                {
                    b.HasOne("EpillBox.API.Models.MedicineForm", "MedicineForm")
                        .WithMany("Medicines")
                        .HasForeignKey("MedicineFormID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EpillBox.API.Models.Producer", "Producer")
                        .WithMany("Medicines")
                        .HasForeignKey("ProducerID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EpillBox.API.Models.ShoppingBasket", b =>
                {
                    b.HasOne("EpillBox.API.Models.User", "User")
                        .WithOne("ShoppingBasket")
                        .HasForeignKey("EpillBox.API.Models.ShoppingBasket", "UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EpillBox.API.Models.ShoppingBasketMedicine", b =>
                {
                    b.HasOne("EpillBox.API.Models.Medicine", "Medicine")
                        .WithMany("ShoppingBasketMedicines")
                        .HasForeignKey("MedicineID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EpillBox.API.Models.ShoppingBasket", "ShoppingBasket")
                        .WithMany("ShoppingBasketMedicines")
                        .HasForeignKey("ShoppingBasketID")
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

            modelBuilder.Entity("EpillBox.API.Models.UsersAllergies", b =>
                {
                    b.HasOne("EpillBox.API.Models.Allergies", "Allergies")
                        .WithMany("UsersAllergies")
                        .HasForeignKey("AllergiesID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EpillBox.API.Models.User", "User")
                        .WithMany("UsersAllergies")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
