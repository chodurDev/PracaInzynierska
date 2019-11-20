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
            
            

            var users = new User[]{
                new User{Name="Bogdan",Surname="Bogdanowicz",Email="bogdan@test.pl"},
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

            var userFirstAidKits = new UserFirstAidKit[]{
                new UserFirstAidKit{UserID=1,FirstAidKitID=1},

                new UserFirstAidKit{UserID=2,FirstAidKitID=2},

                new UserFirstAidKit{UserID=3,FirstAidKitID=3},

                new UserFirstAidKit{UserID=4,FirstAidKitID=4},
            };

            foreach (UserFirstAidKit ufak in userFirstAidKits)
            {
                context.UserFirstAidKits.Add(ufak);
            }
            context.SaveChanges();

            var medicines = new Medicine[]{
               new Medicine{Name="Apap"},
               new Medicine{Name="Ketonal"},
               new Medicine{Name="Ibuprom"},
               new Medicine{Name="No-Spa"},
            };

            foreach (Medicine m in medicines)
            {
                context.Medicines.Add(m);
            }

            context.SaveChanges();

            var firstAidKitMedicines = new FirstAidKitMedicine[]{
                new FirstAidKitMedicine{FirstAidKitID=1,MedicineID=1},
                new FirstAidKitMedicine{FirstAidKitID=1,MedicineID=2},
                new FirstAidKitMedicine{FirstAidKitID=1,MedicineID=3},
                new FirstAidKitMedicine{FirstAidKitID=1,MedicineID=4}
            };

            foreach (FirstAidKitMedicine fakm in firstAidKitMedicines)
            {
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