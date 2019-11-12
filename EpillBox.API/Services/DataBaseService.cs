using EpillBox.API.Data;

namespace EpillBox.API.Services
{
    public class DataBaseService
    {
        protected DataContext _context;

        public DataBaseService(DataContext context)
        {
            _context = context;
        }
    }
}