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
                    .Where(fakm => fakm.FirstAidKitID == item.FirstAidKitID && fakm.ExpirationDate< DateTime.Now)
                    .ToList();
                foreach (var medicine in medicines)
                {
                    expiredMedicines.Add(medicine);
                }
            }
            return expiredMedicines;
        }
        public async Task<IEnumerable<FirstAidKitMedicine>> GetShortTermMedicines(int id)
        {
            var expiredMedicines = new List<FirstAidKitMedicine>();
            var userFirstAidKits = await _context.UserFirstAidKits
                                                    .Where(ufak => ufak.UserID == id)
                                                    .ToListAsync();
            foreach (var item in userFirstAidKits)
            {

                var medicines = _context.FirstAidKitMedicines
                    .Include(fakm => fakm.Medicine)
                    .Where(fakm => fakm.FirstAidKitID == item.FirstAidKitID && IsShorterThanWeek(fakm.ExpirationDate ?? DateTime.Now.AddDays(8)))
                    .ToList();
                foreach (var medicine in medicines)
                {
                    expiredMedicines.Add(medicine);
                }
            }
            return expiredMedicines;
        }
        private bool IsShorterThanWeek(DateTime expirationDate)
        {
            return (int)((expirationDate - DateTime.Today).TotalDays) <= 7 && (int)((expirationDate - DateTime.Today).TotalDays) >= 0;
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
        public async Task<bool> DeleteFirstAidKit(int firstAidKitID)
        {

            var fak = new FirstAidKit { FirstAidKitID = firstAidKitID };
            Delete(fak);
            return await SaveAll();
        }

        public async Task<IEnumerable<Medicine>> GetAllMedicines()
        {
            
            return await _context.Medicines.ToListAsync();
        }
        public void AddMedicineToAllFAK(int id,FirstAidKitMedicine medicine)
        {
            var user = _context.Users.Include(x=>x.UserFirstAidKits).ThenInclude(y=>y.FirstAidKit).ThenInclude(X=>X.FirstAidKitMedicines).FirstOrDefault(x=>x.UserID==id);
            foreach (var apteczka in user.UserFirstAidKits)
            {
                apteczka.FirstAidKit.FirstAidKitMedicines.Add( new FirstAidKitMedicine{MedicineID = medicine.MedicineID, RemainingQuantity=medicine.RemainingQuantity, ExpirationDate=medicine.ExpirationDate});
            }
            
        }

    }
}