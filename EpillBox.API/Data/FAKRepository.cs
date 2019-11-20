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
        public FAKRepository(DataContext context) : base(context){}

        public void Add<T>(T entity) where T : class
        {
           _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<IEnumerable<Medicine>> GetUserMedicines(int id)
        {
            // _context.UserFirstAidKits.Load();
            // _context.Users.Load();
            // _context.FirstAidKits.Load();
            // _context.Medicines.Load();
            // _context.FirstAidKitMedicines.Load();

              var userFirstAidKit = await _context.UserFirstAidKits.FirstOrDefaultAsync(ufak=>ufak.UserID==id);
              var firstAidKitMedicines = await _context.FirstAidKitMedicines.Include(fakm=>fakm.Medicine).Where(fakm=>fakm.FirstAidKitID==userFirstAidKit.FirstAidKitID).Select(x=>x.Medicine).ToListAsync();
            
             
             return  firstAidKitMedicines;
            
             
        }

        public Task<bool> SaveAll()
        {
            throw new System.NotImplementedException();
        }
    }
}