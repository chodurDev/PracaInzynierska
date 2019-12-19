using System;
using System.Linq;
using EpillBox.API.Models;
using Microsoft.EntityFrameworkCore;

namespace EpillBox.API.Data
{
    public static class DbInitializer
    {
        public static void Initialize(DataContext context)
        {
            
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }
            
            
//users---------------------------------------------------------------------------------
            var users = new User[]{
                new User{Name="Bogdan",Surname="Bogdanowicz",Email="bogdan@test.pl",},
                new User{Name="Jan",Surname="Kowalski",Email="jan@test.pl"},
                new User{Name="Tomasz",Surname="Nowak",Email="tomasz@test.pl"},
                new User{Name="Kamil",Surname="Limak",Email="kamil@test.pl"},
            };

            foreach (User u in users)
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash("password", out passwordHash, out passwordSalt);
                u.PasswordHash=passwordHash;
                u.PasswordSalt=passwordSalt;
                u.Name=u.Name.ToLower();
                u.Surname=u.Surname.ToLower();
                context.Users.Add(u);
            }
            context.SaveChanges();
//allergies---------------------------------------------------------------------------------
            var allergies = new Allergies[]{
                new Allergies{Name="ibuprofen"},
                new Allergies{Name = "paracetamol"}
            };

            foreach (Allergies allergy in allergies)
            {
                context.Allergies.Add(allergy);
            }

            context.SaveChanges();
//userAllergies---------------------------------------------------------------------------------
            var userAllergies = new UsersAllergies[]{
                new UsersAllergies{UserID=1,AllergiesID=1},
                new UsersAllergies{UserID=1,AllergiesID=2}
            };
            foreach (UsersAllergies userAllergy in userAllergies)
            {
                context.UsersAllergies.Add(userAllergy);
            }

            context.SaveChanges();

//firstAidKits---------------------------------------------------------------------------------

            var firstAidKits = new FirstAidKit[]{
                    new FirstAidKit{},
                    new FirstAidKit{},
                    new FirstAidKit{},
                    new FirstAidKit{},
            };
            foreach (FirstAidKit fak in firstAidKits)
            {
                context.FirstAidKits.Add(fak);
            }

            context.SaveChanges();
//userFAK---------------------------------------------------------------------------------
            var userFirstAidKits = new UserFirstAidKit[]{
                new UserFirstAidKit{UserID=1,FirstAidKitID=1,Name="apteczka dom"},

                new UserFirstAidKit{UserID=1,FirstAidKitID=2,Name="apteczka biuro"},

                new UserFirstAidKit{UserID=3,FirstAidKitID=3,Name="apteczka dom"},

                new UserFirstAidKit{UserID=4,FirstAidKitID=4,Name="apteczka dom"},
            };

            foreach (UserFirstAidKit ufak in userFirstAidKits)
            {
                context.UserFirstAidKits.Add(ufak);
            }
            context.SaveChanges();
//formMedicine---------------------------------------------------------------------------------
            var forms = new MedicineForm[]{
                new MedicineForm{FormName="tabletka"},
                new MedicineForm{FormName="syrop"}
            };

            foreach (MedicineForm form in forms)
            {
                context.MedicineForms.Add(form);
            }

            context.SaveChanges();

//producer---------------------------------------------------------------------------------
            var producers = new Producer[]{
                new Producer{Name="USP Zdrowie"},
                new Producer{Name="Bayer"},
            };
            foreach (Producer producer in producers)
            {
                context.Producers.Add(producer);
            }

            context.SaveChanges();
//ActiveSubstance-------------------------------------------------------------------------
            var activeSubstances = new ActiveSubstance[]{
                new ActiveSubstance{Name="ibuprofen"},
                new ActiveSubstance{Name="paracetamol"},
                new ActiveSubstance{Name="kwas askorbowy"}
            };
            foreach (ActiveSubstance activeSubstance in activeSubstances)
            {
                context.ActiveSubstances.Add(activeSubstance);
            }

            context.SaveChanges();
//medicines---------------------------------------------------------------------------------
            var medicines = new Medicine[]{
               new Medicine{Name="Apap",QuantityInPackage=10,ProducerID=1,MedicineFormID=1},
               new Medicine{Name="Ketonal",QuantityInPackage=10 ,ProducerID=1,MedicineFormID=1},
               new Medicine{Name="Ibuprom",QuantityInPackage=10 ,ProducerID=1,MedicineFormID=1},
               new Medicine{Name="No-Spa",QuantityInPackage=10 ,ProducerID=1,MedicineFormID=1}
            };

            foreach (Medicine m in medicines)
            {
                context.Medicines.Add(m);
            }

            context.SaveChanges();
//ActiveSubstanceMedicine-------------------------------------------------------------------------
var activeSubstanceMedicines = new ActiveSubstanceMedicine[]{
                new ActiveSubstanceMedicine{ActiveSubstanceID=1,MedicineID=1},
                new ActiveSubstanceMedicine{ActiveSubstanceID=2,MedicineID=2},
                new ActiveSubstanceMedicine{ActiveSubstanceID=3,MedicineID=3},
                new ActiveSubstanceMedicine{ActiveSubstanceID=2,MedicineID=1},
              
            };
            foreach (ActiveSubstanceMedicine activeSubstanceMedicine in activeSubstanceMedicines)
            {
                context.ActiveSubstanceMedicines.Add(activeSubstanceMedicine);
            }

            context.SaveChanges();


//fakMedicines---------------------------------------------------------------------------------
            var currentDayMinus7 = DateTime.Today.AddDays(-7);
           

            var firstAidKitMedicines = new FirstAidKitMedicine[]{
                new FirstAidKitMedicine{FirstAidKitID=1,MedicineID=1,ExpirationDate=currentDayMinus7,IsTaken=true},
                new FirstAidKitMedicine{FirstAidKitID=1,MedicineID=2,ExpirationDate=currentDayMinus7,IsTaken=true},
                new FirstAidKitMedicine{FirstAidKitID=2,MedicineID=3,ExpirationDate=currentDayMinus7,IsTaken=false},
                new FirstAidKitMedicine{FirstAidKitID=2,MedicineID=4,ExpirationDate=DateTime.Today.AddDays(7),IsTaken=false}
            };

            foreach (FirstAidKitMedicine fakm in firstAidKitMedicines)
            {
                fakm.RemainingQuantity=context.Medicines.FirstOrDefault(x=>x.MedicineID==fakm.MedicineID).QuantityInPackage;
                context.FirstAidKitMedicines.Add(fakm);
            }

            context.SaveChanges();
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }

        }

    }
}