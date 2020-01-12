using System.Collections.Generic;
using System.Threading.Tasks;
using EpillBox.API.Dtos;
using EpillBox.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace EpillBox.API.Data
{
    public interface IFAKRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
         void Update<T>(T entity) where T : class;
        Task<bool> SaveAll();
        Task<IEnumerable<FirstAidKitMedicine>> GetUserMedicines(int id);
        Task<IEnumerable<Medicine>> GetAllMedicines();
        Task<IEnumerable<Allergies>> GetAllAllergies();
        Task<IEnumerable<FirstAidKitMedicine>> GetUserChosenFirstAidKitMedicines(int id);
        Task<IEnumerable<FirstAidKitMedicine>> GetExpiredMedicines(int id);
        Task<IEnumerable<FirstAidKitMedicine>> GetShortTermMedicines(int id,int days);
        Task<IEnumerable<FirstAidKitMedicine>> GetUserTakenMedicines(int id);
        Task<IEnumerable<UserFirstAidKit>> GetUserFirstAidKits(int id);
        Task<IEnumerable<ShoppingBasketMedicine>> GetMedicinesToBuy(int id);
        Task<IEnumerable<Allergies>> GetUserAllergies(int id);

        void AddUFAK(UserFirstAidKit uFAK);
        Task<bool> DeleteFirstAidKit(int firstAidKitID);
        Task<bool> DeleteUserAllergy(int allergyId,int userId);
        void AddMedicineToAllFAK(int id,FirstAidKitMedicine medicine);
        void AddMedicineToBuy(int id,int  medicineId);
        void AddAllergyToUserAllergies(int id,IEnumerable<Allergies> allergies);
        void AddMedicineToDatabase(MedicineToAdd medicine);
    }
}