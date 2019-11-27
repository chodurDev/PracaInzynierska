using System.Collections.Generic;
using System.Threading.Tasks;
using EpillBox.API.Models;

namespace EpillBox.API.Data
{
    public interface IFAKRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
        Task<IEnumerable<FirstAidKitMedicine>> GetUserMedicines(int id);
        Task<IEnumerable<FirstAidKitMedicine>> GetUserChosenFirstAidKitMedicines(int id);
        Task<IEnumerable<FirstAidKitMedicine>> GetExpiredMedicines(int id);
        Task<IEnumerable<FirstAidKitMedicine>> GetUserTakenMedicines(int id);
        Task<IEnumerable<UserFirstAidKit>> GetUserFirstAidKits(int id);
    }
}