using System.Collections.Generic;
using AutoMapper;
using EpillBox.API.Dtos;
using EpillBox.API.Models;
using System.Linq;

namespace EpillBox.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            
            
            var medicinesToReturn = CreateMap<FirstAidKitMedicine,UserMedicinesToViewDto>();
            medicinesToReturn.ForMember(x=>x.ExpirationDate,y=>y.MapFrom(j=>j.ExpirationDate));
            medicinesToReturn.ForMember(x=>x.FirstAidKitID,y=>y.MapFrom(j=>j.FirstAidKitID));
            medicinesToReturn.ForMember(x=>x.FirstAidKitMedicineID,y=>y.MapFrom(j=>j.FirstAidKitMedicineID));
            medicinesToReturn.ForMember(x=>x.Name,y=>y.MapFrom(j=>j.Medicine.Name));
            medicinesToReturn.ForMember(x=>x.QuantityInPackage,y=>y.MapFrom(j=>j.Medicine.QuantityInPackage));
            medicinesToReturn.ForMember(x=>x.MedicineID,y=>y.MapFrom(j=>j.MedicineID));
            medicinesToReturn.ForMember(x=>x.RemainingQuantity,y=>y.MapFrom(j=>j.RemainingQuantity));
            medicinesToReturn.ForMember(x=>x.FakName,y=>y.MapFrom(j=>j.FirstAidKit.UserFirstAidKits.FirstOrDefault().Name));
            medicinesToReturn.ForMember(x=>x.Form,y=>y.MapFrom(j=>j.Medicine.MedicineForm.FormName));
            medicinesToReturn.ForMember(x=>x.Producer,y=>y.MapFrom(j=>j.Medicine.Producer.Name));
            medicinesToReturn.ForMember(x=>x.ActiveSubstance,y=>y.MapFrom(j=>j.Medicine.ActiveSubstanceMedicines.Select(x=>x.ActiveSubstance.Name)));


            var medicinesToUpdate = CreateMap<UserMedicinesToViewDto,FirstAidKitMedicine>();
            // medicinesToUpdate.ForMember(x=>x.ExpirationDate,y=>y.MapFrom(j=>j.ExpirationDate));
            // medicinesToUpdate.ForMember(x=>x.FirstAidKitID,y=>y.MapFrom(j=>j.FirstAidKitID));
            // medicinesToUpdate.ForMember(x=>x.FirstAidKitMedicineID,y=>y.MapFrom(j=>j.FirstAidKitMedicineID));
            medicinesToUpdate.ForPath(x=>x.Medicine.Name,y=>y.MapFrom(j=>j.Name));
            medicinesToUpdate.ForPath(x=>x.Medicine.QuantityInPackage,y=>y.MapFrom(j=>j.QuantityInPackage));
            medicinesToUpdate.ForPath(x=>x.MedicineID,y=>y.MapFrom(j=>j.MedicineID));
            // medicinesToUpdate.ForMember(x=>x.RemainingQuantity,y=>y.MapFrom(j=>j.RemainingQuantity));
            // medicinesToUpdate.ForPath(x=>x.FirstAidKit.UserFirstAidKits.Single().Name,y=>y.MapFrom(j=>j.FakName));
            medicinesToUpdate.ForPath(x=>x.Medicine.MedicineForm.FormName,y=>y.MapFrom(j=>j.Form));
            medicinesToUpdate.ForPath(x=>x.Medicine.Producer.Name,y=>y.MapFrom(j=>j.Producer));
            // medicinesToUpdate.ForPath(x=>x.Medicine.ActiveSubstanceMedicines.Select(z=>z.ActiveSubstance.Name),y=>y.MapFrom(j=>j.ActiveSubstance));
            // medicinesToUpdate.ForMember(x=>x.FirstServingAt,y=>y.MapFrom(j=>j.FirstServingAt));
            // medicinesToUpdate.ForMember(x=>x.ServingSize,y=>y.MapFrom(j=>j.ServingSize));
            // medicinesToUpdate.ForMember(x=>x.NumberOfServings,y=>y.MapFrom(j=>j.NumberOfServings));
            // medicinesToUpdate.ForMember(x=>x.IsTaken,y=>y.MapFrom(j=>j.IsTaken));





            var medicinesToAdd = CreateMap<FirstAidKitMedicineToAddDto,FirstAidKitMedicine>();

            medicinesToAdd.ForMember(x=>x.FirstAidKitID,y=>y.MapFrom(j=>j.FirstAidKitID));
            medicinesToAdd.ForMember(x=>x.IsTaken,y=>y.MapFrom(j=>j.IsTaken));
            medicinesToAdd.ForMember(x=>x.MedicineID,y=>y.MapFrom(j=>j.MedicineID));
            medicinesToAdd.ForMember(x=>x.RemainingQuantity,y=>y.MapFrom(j=>j.RemainingQuantity));
            medicinesToAdd.ForMember(x=>x.ExpirationDate,y=>y.MapFrom(j=>j.ExpirationDate));
         

            var medicinesToBuy = CreateMap<ShoppingBasketMedicine,MedicineToViewDto>();
            medicinesToBuy.ForMember(x=>x.MedicineID,y=>y.MapFrom(j=>j.MedicineID));
            medicinesToBuy.ForMember(x=>x.Name,y=>y.MapFrom(j=>j.Medicine.Name));
            medicinesToBuy.ForMember(x=>x.QuantityInPackage,y=>y.MapFrom(j=>j.Medicine.QuantityInPackage));
            medicinesToBuy.ForMember(x=>x.Producer,y=>y.MapFrom(j=>j.Medicine.Producer.Name));
            medicinesToBuy.ForMember(x=>x.Form,y=>y.MapFrom(j=>j.Medicine.MedicineForm.FormName));
            medicinesToBuy.ForMember(x=>x.ActiveSubstance,y=>y.MapFrom(j=>j.Medicine.ActiveSubstanceMedicines.Select(x=>x.ActiveSubstance.Name)));

            var medicineToView = CreateMap<Medicine,MedicineToViewDto>();
            medicineToView.ForMember(x=>x.Producer,y=>y.MapFrom(j=>j.Producer.Name));
            medicineToView.ForMember(x=>x.Form,y=>y.MapFrom(j=>j.MedicineForm.FormName));
            medicineToView.ForMember(x=>x.ActiveSubstance,y=>y.MapFrom(j=>j.ActiveSubstanceMedicines.Select(x=>x.ActiveSubstance.Name)));
            

            // var medicineToDatabase = CreateMap<MedicineToAdd,Medicine>();
            // medicineToDatabase.ForMember(x=>x.Name,y=>y.MapFrom(z=>z.Name));
            // medicineToDatabase.ForMember(x=>x.QuantityInPackage,y=>y.MapFrom(z=>z.QuantityInPackage));
            // medicineToDatabase.ForMember(x=>x.Producer.Name,y=>y.MapFrom(z=>z.Producer));
            // medicineToDatabase.ForMember(x=>x.MedicineForm.MedicineFormID,y=>y.MapFrom(z=>z.Form));
            // medicineToDatabase.ForMember(x=>x.ActiveSubstanceMedicines.Select(j=>j.ActiveSubstance.Name),y=>y.MapFrom(z=>z.ActiveSubstance));


        }
    }
}