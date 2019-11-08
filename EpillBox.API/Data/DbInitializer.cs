using System.Linq;
using EpillBox.API.Models;

namespace EpillBox.API.Data
{
    public static class DbInitializer
    {
        public static void Initialize(DataContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            //usuwac baze danych w momencie jesli ona istnieje i ponownie seedowac dane
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }

            var users = new User[]{
                new User{Name="Bogdan",Surname="Bogdanowicz",Email="test@test.pl",Login="login",Password="password"},
                new User{Name="Jan",Surname="Kowalski",Email="test@test.pl",Login="login",Password="password"},
                new User{Name="Tomasz",Surname="Nowak",Email="test@test.pl",Login="login",Password="password"},
                new User{Name="Kamil",Surname="Limak",Email="test@test.pl",Login="login",Password="password"},
            };

            foreach (User u in users)
            {
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

    }
}