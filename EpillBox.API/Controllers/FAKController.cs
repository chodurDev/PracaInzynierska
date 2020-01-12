using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using EpillBox.API.Data;
using EpillBox.API.Dtos;
using EpillBox.API.Models;
using EpillBox.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EpillBox.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FAKController : ControllerBase
    {

        private readonly IFAKRepository _fakRepo;
        private readonly IMapper _mapper;

        public FAKController(IFAKRepository fakRepo, IMapper mapper)
        {
            _mapper = mapper;
            _fakRepo = fakRepo;

        }

        // GET api/fak/5

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserMedicines(int id)
        {
            var userMedicines = await _fakRepo.GetUserMedicines(id);
            var medicinesToReturn = _mapper.Map<IEnumerable<UserMedicinesToViewDto>>(userMedicines);

            return Ok(medicinesToReturn);

        }

        [HttpGet("getUserChosenFirstAidKitMedicines/{id}")]
        public async Task<IActionResult> GetUserChosenFirstAidKitMedicines(int id)
        {
            var userMedicines = await _fakRepo.GetUserChosenFirstAidKitMedicines(id);
            var medicinesToReturn = _mapper.Map<IEnumerable<UserMedicinesToViewDto>>(userMedicines);
            return Ok(medicinesToReturn);

        }
        [HttpGet("getAllMedicines")]
        public async Task<IActionResult> GetAllMedicines()
        {
            //make dto to get this medicines
            var medicines = await _fakRepo.GetAllMedicines();
            var medicinesToReturn =_mapper.Map<IEnumerable<MedicineToViewDto>>(medicines);
            return Ok(medicinesToReturn);
            // return Ok();

        }
        [HttpGet("getAllAllergies")]
        public async Task<IActionResult> GetAllAllergies()
        {
            var allergies = await _fakRepo.GetAllAllergies();
            return Ok(allergies);
        }

        [HttpGet("getUserTakenMedicines/{id}")]
        public async Task<IActionResult> GetUserTakenMedicines(int id)
        {
            var userMedicines = await _fakRepo.GetUserTakenMedicines(id);
            var medicinesToReturn = _mapper.Map<IEnumerable<UserMedicinesToViewDto>>(userMedicines);

            return Ok(medicinesToReturn);

        }

        [Route("shortTermMedicines/{id}/{days}")]
        public async Task<IActionResult> GetShortTermMedicines(int id,int days)
        {
            var expiredMedicines = await _fakRepo.GetShortTermMedicines(id,days);
            var medicinesToReturn = _mapper.Map<IEnumerable<UserMedicinesToViewDto>>(expiredMedicines);
            return Ok(medicinesToReturn);

        }
        [Route("expiredMedicines/{id}")]
        public async Task<IActionResult> GetExpiredMedicines(int id)
        {
            var expiredMedicines = await _fakRepo.GetExpiredMedicines(id);
            var medicinesToReturn = _mapper.Map<IEnumerable<UserMedicinesToViewDto>>(expiredMedicines);
            return Ok(medicinesToReturn);

        }


        [Route("getUserFirstAidKits/{id}")]
        public async Task<IActionResult> GetUserFirstAidKits(int id)
        {
            var expiredMedicines = await _fakRepo.GetUserFirstAidKits(id);

            return Ok(expiredMedicines);

        }
        [Route("getUserAllergies/{id}")]
        public async Task<IActionResult> GetUserAllergies(int id)
        {
            var userAllergies = await _fakRepo.GetUserAllergies(id);

            return Ok(userAllergies);

        }

        [Route("getMedicinesToBuy/{id}")]
        public async Task<IActionResult> GetMedicinesToBuy(int id)
        {
            var medicinesToBuy = await _fakRepo.GetMedicinesToBuy(id);
            var medicinesToReturn = _mapper.Map<IEnumerable<MedicineToViewDto>>(medicinesToBuy);

            return Ok(medicinesToReturn);

        }



        // POST api/fak/addUFAK

        [HttpPost("addUFAK")]
        public async Task<IActionResult> Post([FromBody] UserFirstAidKit uFAK)
         {

            _fakRepo.AddUFAK(uFAK);
            if (await _fakRepo.SaveAll())
                return Ok();
            throw new System.Exception($"Adding ufak failed on save");
        }

        [HttpPost("addMedicineToBuy/{id}")]
        public async Task<IActionResult> AddMedicineToBuy(int id,[FromBody]int medicineId)
        {
            _fakRepo.AddMedicineToBuy(id,medicineId);
            if (await _fakRepo.SaveAll())
                return Ok();
            throw new System.Exception($"Adding medicine to shoppingBasket failed on save");
        }

        [HttpPost("addFAKMedicine")]
        public async Task<IActionResult> AddFAKMedicine([FromBody] FirstAidKitMedicineToAddDto fakMedicine)
        {
            // if(fakMedicine.FirstAidKitID==-1){

            // }
            var fakMedicineToAdd = _mapper.Map<FirstAidKitMedicine>(fakMedicine);
           _fakRepo.Add(fakMedicineToAdd);    
           if (await _fakRepo.SaveAll())
                return Ok();
            throw new System.Exception($"Adding fakMedicine failed on save");
        }


        [HttpPost("addAllergyToUserAllergies/{id}")]
        public async Task<IActionResult> AddAllergyToUserAllergies([FromBody] IEnumerable<Allergies> allergies, int id)
        {
            _fakRepo.AddAllergyToUserAllergies(id,allergies);
            await _fakRepo.SaveAll();
            return Ok();
           
        }


        [HttpPost("addMedicineToAllFAK/{id}")]
        public async Task<IActionResult> AddMedicineToAllFAK([FromBody] FirstAidKitMedicineToAddDto fakMedicine,int id)
        {
            // if(fakMedicine.FirstAidKitID==-1){

            // }
            var fakMedicineToAdd = _mapper.Map<FirstAidKitMedicine>(fakMedicine);
           _fakRepo.AddMedicineToAllFAK(id,fakMedicineToAdd);   
           if (await _fakRepo.SaveAll())
                return Ok();
            throw new System.Exception($"Adding fakMedicine failed on save");
        }

        [HttpPost("addMedicine")]
        public async Task<IActionResult> AddMedicine([FromBody] MedicineToAdd medicine)
        {
            _fakRepo.AddMedicineToDatabase(medicine);
            if(await _fakRepo.SaveAll()){

                return Ok();
            }
            return BadRequest("Dany lek już istnieje");
        }

        // PUT api/fak/5

        [HttpPut]
        public async Task<IActionResult> Put(FirstAidKitMedicineToAddDto value)
        {
            var fakMedicineToUpdate = _mapper.Map<FirstAidKitMedicine>(value);
            _fakRepo.Update(fakMedicineToUpdate);
            if (await _fakRepo.SaveAll())
                return NoContent();

            throw new System.Exception("Updating FakMedicine failed on save");
        }

        // DELETE api/fak/deleteFAKMedicine/5

        [HttpDelete("deleteFAKMedicine/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var fakMedicineToRemove = new FirstAidKitMedicine { FirstAidKitMedicineID = id };
            _fakRepo.Delete(fakMedicineToRemove);
            if (await _fakRepo.SaveAll())
                return NoContent();

            throw new System.Exception($"Deleting FakMedicine {id} failed on save");

        }
        // DELETE api/fak/deleteFAK/5

        [HttpDelete("deleteFAK/{id}")]
        public async Task<IActionResult> DeleteFAK(int id)
        {

            if (await _fakRepo.DeleteFirstAidKit(id))
                return NoContent();

            throw new System.Exception($"Deleting FakMedicine {id} failed on save");

        }
        [HttpDelete("deleteUserAllergy/{allergyId}/{userId}")]
        public async Task<IActionResult> DeleteUserAllergy(int allergyId,int userId)
        {

            if (await _fakRepo.DeleteUserAllergy(allergyId,userId))
                return NoContent();

            throw new System.Exception($"Deleting UserAllergy failed on save");

        }
    }
}
