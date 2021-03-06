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

            var medicinesToAdd = CreateMap<FirstAidKitMedicineToAddDto,FirstAidKitMedicine>();

            medicinesToAdd.ForMember(x=>x.FirstAidKitID,y=>y.MapFrom(j=>j.FirstAidKitID));
            medicinesToAdd.ForMember(x=>x.IsTaken,y=>y.MapFrom(j=>j.IsTaken));
            medicinesToAdd.ForMember(x=>x.MedicineID,y=>y.MapFrom(j=>j.MedicineID));
            medicinesToAdd.ForMember(x=>x.RemainingQuantity,y=>y.MapFrom(j=>j.RemainingQuantity));
            medicinesToAdd.ForMember(x=>x.ExpirationDate,y=>y.MapFrom(j=>j.ExpirationDate));
         
        }
    }
}