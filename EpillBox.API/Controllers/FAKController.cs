using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using EpillBox.API.Data;
using EpillBox.API.Dtos;
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
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserMedicines(int id)
        {
            var userMedicines = await _fakRepo.GetUserMedicines(id);
            var medicinesToReturn = _mapper.Map<IEnumerable<UserMedicinesToViewDto>>(userMedicines);

            return Ok(medicinesToReturn);

        }
        [AllowAnonymous]
        [HttpGet("getUserChosenFirstAidKitMedicines/{id}")]
        public async Task<IActionResult> GetUserChosenFirstAidKitMedicines(int id)
        {
            var userMedicines = await _fakRepo.GetUserChosenFirstAidKitMedicines(id);
            var medicinesToReturn = _mapper.Map<IEnumerable<UserMedicinesToViewDto>>(userMedicines);
            return Ok(medicinesToReturn);

        }
        [AllowAnonymous]
        [HttpGet("getUserTakenMedicines/{id}")]
        public async Task<IActionResult> GetUserTakenMedicines(int id)
        {
            var userMedicines = await _fakRepo.GetUserTakenMedicines(id);
            var medicinesToReturn = _mapper.Map<IEnumerable<UserMedicinesToViewDto>>(userMedicines);

            return Ok(medicinesToReturn);

        }
        [AllowAnonymous]
        [Route("expiredMedicines/{id}")]
        public async Task<IActionResult> GetExpiredMedicines(int id)
        {
            var expiredMedicines = await _fakRepo.GetExpiredMedicines(id);
            var medicinesToReturn = _mapper.Map<IEnumerable<UserMedicinesToViewDto>>(expiredMedicines);
            return Ok(medicinesToReturn);

        }

        [AllowAnonymous]
        [Route("getUserFirstAidKits/{id}")]
        public async Task<IActionResult> GetUserFirstAidKits(int id)
        {
            var expiredMedicines = await _fakRepo.GetUserFirstAidKits(id);

            return Ok(expiredMedicines);

        }




        // POST api/fak
        [AllowAnonymous]
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/fak/5
        [AllowAnonymous]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UserMedicinesToViewDto value)
        {
            await _fakRepo.Update(id,value);
            if(await _fakRepo.SaveAll())
                return NoContent();
           
           throw new System.Exception($"Updating FakMedicine {id} failed on save");
        }

        // DELETE api/fak/5
        [AllowAnonymous]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var fakMedicineToRemove = await _fakRepo.Search(id);
            _fakRepo.Delete(fakMedicineToRemove);
            if(await _fakRepo.SaveAll())
                return NoContent();
           
           throw new System.Exception($"Deleting FakMedicine {id} failed on save");

        }
    }
}
