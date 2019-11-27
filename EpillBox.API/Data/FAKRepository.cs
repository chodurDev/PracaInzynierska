using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EpillBox.API.Models;
using EpillBox.API.Services;
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
                    .Where(fakm => fakm.FirstAidKitID == item.FirstAidKitID  && fakm.ExpirationDate < DateTime.Today)
                    .ToList();
                foreach (var medicine in medicines)
                {
                    expiredMedicines.Add(medicine);
                }
            }
            return expiredMedicines;
        }
        public async Task<IEnumerable<FirstAidKitMedicine>> GetUserTakenMedicines(int id)
        {
            var takenMedicines = new List<FirstAidKitMedicine>();
            var userFirstAidKits = await _context.UserFirstAidKits
                                                    .Where(ufak => ufak.UserID == id)
                                                    .ToListAsync();
            foreach (var item in userFirstAidKits)
            {
                var medicines = _context.FirstAidKitMedicines
                    .Include(fakm => fakm.Medicine)
                    .Where(fakm => fakm.FirstAidKitID == item.FirstAidKitID  && fakm.IsTaken == true)
                    .ToList();
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

        public Task<bool> SaveAll()
        {
            throw new System.NotImplementedException();
        }
    }
}