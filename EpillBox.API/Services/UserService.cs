using System.Collections.Generic;
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

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }
    }
}