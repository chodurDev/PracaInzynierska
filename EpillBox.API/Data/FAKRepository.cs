using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EpillBox.API.Dtos;
using EpillBox.API.Models;
using EpillBox.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EpillBox.API.Data
{
    public class FAKRepository : DataBaseService, IFAKRepository
    {
        public FAKRepository(DataContext context) : base(context) { }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }


        public async Task<IEnumerable<FirstAidKitMedicine>> GetUserMedicines(int id)
        {
            var firstAidKitMedicines = new List<FirstAidKitMedicine>();
            var userFirstAidKits = await _context.UserFirstAidKits
                                                    .Where(ufak => ufak.UserID == id)
                                                    .ToListAsync();
            foreach (var item in userFirstAidKits)
            {
                var medicines = _context.FirstAidKitMedicines
                    .Include(fakm => fakm.Medicine)
                            .ThenInclude(m => m.Producer)
                    .Include(fakm => fakm.Medicine)
                            .ThenInclude(m => m.MedicineForm)
                    .Include(fakm => fakm.Medicine)
                            .ThenInclude(m => m.ActiveSubstanceMedicines)
                            .ThenInclude(asm => asm.ActiveSubstance)
                    .Include(x => x.FirstAidKit)
                            .ThenInclude(y => y.UserFirstAidKits)

                    .Where(fakm => fakm.FirstAidKitID == item.FirstAidKitID)
                    .ToList();
                foreach (var medicine in medicines)
                {
                    firstAidKitMedicines.Add(medicine);
                }
            }

            return firstAidKitMedicines;
        }
        public async Task<IEnumerable<FirstAidKitMedicine>> GetUserChosenFirstAidKitMedicines(int id)
        {
            var userChosenFirstAidKit = await _context.UserFirstAidKits
                                                        .FirstOrDefaultAsync(ufak => ufak.FirstAidKitID == id);
            var firstAidKitMedicines = await _context.FirstAidKitMedicines
                                                        .Include(fakm => fakm.Medicine)
                                                                .ThenInclude(m => m.Producer)
                                                        .Include(fakm => fakm.Medicine)
                                                                .ThenInclude(m => m.MedicineForm)
                                                        .Include(fakm => fakm.Medicine)
                                                                .ThenInclude(m => m.ActiveSubstanceMedicines)
                                                                .ThenInclude(asm => asm.ActiveSubstance)
                                                        .Include(x => x.FirstAidKit)
                                                                .ThenInclude(y => y.UserFirstAidKits)
                                                        .Where(fakm => fakm.FirstAidKitID == userChosenFirstAidKit.FirstAidKitID)
                                                        .ToListAsync();

            return firstAidKitMedicines;
        }
        public async Task<IEnumerable<FirstAidKitMedicine>> GetExpiredMedicines(int id)
        {
            var expiredMedicines = new List<FirstAidKitMedicine>();
            var userFirstAidKits = await _context.UserFirstAidKits
                                                    .Where(ufak => ufak.UserID == id)
                                                    .ToListAsync();
            foreach (var item in userFirstAidKits)
            {

                var medicines = _context.FirstAidKitMedicines
                    .Include(fakm => fakm.Medicine)
                    .Where(fakm => fakm.FirstAidKitID == item.FirstAidKitID && fakm.ExpirationDate < DateTime.Now)
                    .ToList();
                foreach (var medicine in medicines)
                {
                    expiredMedicines.Add(medicine);
                }
            }
            return expiredMedicines;
        }
        public async Task<IEnumerable<FirstAidKitMedicine>> GetShortTermMedicines(int id, int days)
        {
            var expiredMedicines = new List<FirstAidKitMedicine>();
            var userFirstAidKits = await _context.UserFirstAidKits
                                                    .Where(ufak => ufak.UserID == id)
                                                    .ToListAsync();
            foreach (var item in userFirstAidKits)
            {

                var medicines = _context.FirstAidKitMedicines
                    .Include(fakm => fakm.Medicine)
                    .Where(fakm => fakm.FirstAidKitID == item.FirstAidKitID && IsShorterThan(fakm.ExpirationDate ?? DateTime.Now.AddDays(8), days))
                    .ToList();
                foreach (var medicine in medicines)
                {
                    expiredMedicines.Add(medicine);
                }
            }
            return expiredMedicines;
        }
        private bool IsShorterThan(DateTime expirationDate, int days)
        {
            return (int)((expirationDate - DateTime.Today).TotalDays) <= days && (int)((expirationDate - DateTime.Today).TotalDays) >= 0;
        }
        public async Task<IEnumerable<FirstAidKitMedicine>> GetUserTakenMedicines(int id)
        {
            var takenMedicines = new List<FirstAidKitMedicine>();
            var userFirstAidKits = await _context.UserFirstAidKits
                                                    .Where(ufak => ufak.UserID == id)
                                                    .ToListAsync();
            foreach (var item in userFirstAidKits)
            {
                var medicines = await _context.FirstAidKitMedicines
                    .Include(fakm => fakm.Medicine)
                    .Where(fakm => fakm.FirstAidKitID == item.FirstAidKitID && fakm.IsTaken == true)
                    .ToListAsync();
                foreach (var medicine in medicines)
                {
                    takenMedicines.Add(medicine);
                }
            }
            return takenMedicines;
        }
        public async Task<IEnumerable<ShoppingBasketMedicine>> GetMedicinesToBuy(int id)
        {
            var medicinesToBuy = await _context.ShoppingBasketMedicines
            .Include(x => x.Medicine)
                .ThenInclude(y => y.ActiveSubstanceMedicines)
                .ThenInclude(z => z.ActiveSubstance)
            .Include(x => x.Medicine)
                .ThenInclude(y => y.Producer)
            .Include(x => x.Medicine)
                .ThenInclude(y => y.MedicineForm)
            .Where(x => x.ShoppingBasket.UserID == id)
            .ToListAsync();
            return medicinesToBuy;
        }
        public async Task<IEnumerable<Allergies>> GetUserAllergies(int id)
        {
           
            var userAllergies = await _context.UsersAllergies
            .Include(x=>x.User)
            .Include(x=>x.Allergies)
            
            .Where(x =>x.UserID==id)
            .Select(x=>x.Allergies)
            .ToListAsync();
            return userAllergies;
        }
        public async Task<IEnumerable<UserFirstAidKit>> GetUserFirstAidKits(int id)
        {
            return await _context.UserFirstAidKits
                                    .Where(ufak => ufak.UserID == id)
                                    .ToListAsync();

        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update<T>(T entity) where T : class
        {

            _context.Update(entity);
        }


        public void AddUFAK(UserFirstAidKit uFAK)
        {
            var fak = new FirstAidKit() { UserFirstAidKits = new List<UserFirstAidKit> { uFAK } };
            Add(fak);

        }
        public void AddAllergyToUserAllergies(int id,IEnumerable<Allergies> allergies)
        {
            bool temp;
            foreach (var item in allergies)
            {
                temp = _context.UsersAllergies.All(x=>x.AllergiesID!=item.AllergiesID);

                if(_context.UsersAllergies.Where(x=>x.UserID==id).All(x=>x.AllergiesID!=item.AllergiesID))
                {
                    Add(new UsersAllergies{AllergiesID=item.AllergiesID,UserID=id});
                }
            }
            

        }
        public async Task<bool> DeleteFirstAidKit(int firstAidKitID)
        {

            var fak = new FirstAidKit { FirstAidKitID = firstAidKitID };
            Delete(fak);
            return await SaveAll();
        }
        public async Task<bool> DeleteUserAllergy(int allergyId,int userId)
        {
            Delete(await _context.UsersAllergies.Where(x=>x.UserID==userId).FirstOrDefaultAsync(x=>x.AllergiesID==allergyId));
            return await SaveAll();
        }

        public async Task<IEnumerable<Medicine>> GetAllMedicines()
        {

            return await _context.Medicines.Include(x => x.MedicineForm).Include(x => x.Producer).Include(x => x.ActiveSubstanceMedicines).ThenInclude(y => y.ActiveSubstance).ToListAsync();
        }
        public async Task<IEnumerable<Allergies>> GetAllAllergies()
        {
            return await _context.Allergies.ToListAsync();
        }
        public void AddMedicineToAllFAK(int id, FirstAidKitMedicine medicine)
        {
            var user = _context.Users.Include(x => x.UserFirstAidKits).ThenInclude(y => y.FirstAidKit).ThenInclude(X => X.FirstAidKitMedicines).FirstOrDefault(x => x.UserID == id);
            foreach (var apteczka in user.UserFirstAidKits)
            {
                apteczka.FirstAidKit.FirstAidKitMedicines.Add(new FirstAidKitMedicine { MedicineID = medicine.MedicineID, RemainingQuantity = medicine.RemainingQuantity, ExpirationDate = medicine.ExpirationDate });
            }

        }

        public void AddMedicineToBuy(int id, int medicineId)
        {
            if (_context.ShoppingBaskets.Any(x => x.UserID == id) == false)
            {
                Add(new ShoppingBasketMedicine { ShoppingBasket = new ShoppingBasket { UserID = id }, MedicineID = medicineId });
            }
            else
            {
                var shoppingBasketId = _context.ShoppingBaskets.FirstOrDefault(x => x.UserID == id).ShoppingBasketID;
                var medicineToBuy = new ShoppingBasketMedicine { ShoppingBasketID = shoppingBasketId, MedicineID = medicineId };
                Add(medicineToBuy);
            }

        }


    }
}