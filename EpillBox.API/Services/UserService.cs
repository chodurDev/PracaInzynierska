using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EpillBox.API.Data;
using EpillBox.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EpillBox.API.Services
{
    public class UserService : DataBaseService
    {
        public UserService(DataContext context) : base(context){}

        public async Task<IEnumerable<Medicine>> GetUsers()
        {
           
            _context.UserFirstAidKits.Load();
            _context.Users.Load();
            _context.FirstAidKits.Load();
            _context.Medicines.Load();
            _context.FirstAidKitMedicines.Load();

             var users = await _context.Medicines.Include(m=>m.FirstAidKitMedicines).ToListAsync();
            
             

           
             
            return users;
        }
    }
}