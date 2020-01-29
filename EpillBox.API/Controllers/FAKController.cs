﻿using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using EpillBox.API.Data;
using EpillBox.API.Dtos;
using EpillBox.API.Helpers;
using EpillBox.API.Hubs;
using EpillBox.API.Models;
using EpillBox.API.Services;
using Hangfire;
using Hangfire.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace EpillBox.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FAKController : ControllerBase
    {

        private readonly IFAKRepository _fakRepo;
        private readonly IMapper _mapper;
        private readonly EmailService _emailService;
        private readonly IHubContext<ChatHub> _hub;
        private readonly RecurringJobManager _recurringJob;

        public FAKController(IFAKRepository fakRepo, IMapper mapper, EmailService emailService, IHubContext<ChatHub> hub)
        {
            _recurringJob = new RecurringJobManager();
            _hub = hub;
            _emailService = emailService;
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
            var medicinesToReturn = _mapper.Map<IEnumerable<MedicineToViewDto>>(medicines);
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
        public async Task<IActionResult> GetShortTermMedicines(int id, int days)
        {
            var expiredMedicines = await _fakRepo.GetShortTermMedicines(id, days);
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
        [Route("getMedicinesUserCantTake/{id}")]
        public async Task<IActionResult> GetMedicinesUserCantTake(int id)
        {
            var medicinesCantTake = await _fakRepo.GetMedicinesUserCantTake(id);
            var medicinesToReturn = _mapper.Map<IEnumerable<MedicineToViewDto>>(medicinesCantTake);
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

        [Route("sendShoppingList/{id}")]
        public async Task<IActionResult> SendShoppingList(int id)
        {
            var user = _fakRepo.GetUser(id);
            var medicinesToBuy = await _fakRepo.GetMedicinesToBuy(id);
            var medicinesToReturn = _mapper.Map<IEnumerable<MedicineToViewDto>>(medicinesToBuy);
            var listOfMedicines = new List<string>();
            foreach (var item in medicinesToReturn)
            {
                listOfMedicines.Add(
                    item.Name.ToUpper() +
                    " Producent: " + item.Producer.ToUpper() +
                    " Forma: " + item.Form.ToUpper() +
                    " Ilość szt. w opakowaniu: " + item.QuantityInPackage
                    );
            }
            _emailService.SendEmail(user, listOfMedicines);

            return Ok();


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
        public async Task<IActionResult> AddMedicineToBuy(int id, [FromBody]int medicineId)
        {
            _fakRepo.AddMedicineToBuy(id, medicineId);
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
            _fakRepo.AddAllergyToUserAllergies(id, allergies);
            await _fakRepo.SaveAll();
            return Ok();

        }


        [HttpPost("addMedicineToAllFAK/{id}")]
        public async Task<IActionResult> AddMedicineToAllFAK([FromBody] FirstAidKitMedicineToAddDto fakMedicine, int id)
        {
            // if(fakMedicine.FirstAidKitID==-1){

            // }
            var fakMedicineToAdd = _mapper.Map<FirstAidKitMedicine>(fakMedicine);
            _fakRepo.AddMedicineToAllFAK(id, fakMedicineToAdd);
            if (await _fakRepo.SaveAll())
                return Ok();
            throw new System.Exception($"Adding fakMedicine failed on save");
        }

        [HttpPost("addMedicine")]
        public async Task<IActionResult> AddMedicine([FromBody] MedicineToAdd medicine)
        {
            _fakRepo.AddMedicineToDatabase(medicine);
            if (await _fakRepo.SaveAll())
            {

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

            if (!fakMedicineToUpdate.IsTaken)
            {
               _recurringJob.RemoveIfExists(fakMedicineToUpdate.FirstAidKitMedicineID.ToString());
                await _hub.Clients.All.SendAsync("messageReceived", "wyłączyłeś harmonogram leku");
            }

            if (await _fakRepo.SaveAll())
                return NoContent();

            throw new System.Exception("Updating FakMedicine failed on save");
        }

        [HttpPut("setSchedule")]
        public async Task<IActionResult> SetSchedule(UserMedicinesToViewDto value)
        {
            var fakMedicineToUpdate = _mapper.Map<FirstAidKitMedicine>(value);
            _fakRepo.Update(fakMedicineToUpdate);
            if (await _fakRepo.SaveAll())
            {
                var interval = (24 - fakMedicineToUpdate.FirstServingAt.Hour) / fakMedicineToUpdate.NumberOfServings;
                var cronSettings="0 "+fakMedicineToUpdate.FirstServingAt.Minute+" "+fakMedicineToUpdate.FirstServingAt.Hour+"/"+interval+" * * ?";
                
                _recurringJob.AddOrUpdate(fakMedicineToUpdate.FirstAidKitMedicineID.ToString(), ()=>ViewReminder(fakMedicineToUpdate.Medicine.Name), cronSettings);
                return NoContent();

            }

            throw new System.Exception("Updating FakMedicine failed on save");
        }
        public async Task ViewReminder(string fakMedicineName)
        {

            await _hub.Clients.All.SendAsync("messageReceived", "zażyj " + fakMedicineName);

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
        public async Task<IActionResult> DeleteUserAllergy(int allergyId, int userId)
        {

            if (await _fakRepo.DeleteUserAllergy(allergyId, userId))
                return NoContent();

            throw new System.Exception($"Deleting UserAllergy failed on save");

        }
    }
}
