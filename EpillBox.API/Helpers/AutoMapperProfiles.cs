using System.Collections.Generic;
using AutoMapper;
using EpillBox.API.Dtos;
using EpillBox.API.Models;

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
        }
    }
}