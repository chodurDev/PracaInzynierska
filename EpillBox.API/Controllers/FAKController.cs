using System.Threading.Tasks;
using EpillBox.API.Data;
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

        public FAKController(IFAKRepository fakRepo)
        {
            _fakRepo = fakRepo;
            
        }

        // GET api/fak/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserMedicines(int id)
        {
            var userMedicines = await _fakRepo.GetUserMedicines(id);

            return Ok(userMedicines);
            
        }
        [AllowAnonymous]
        [HttpGet("getUserChosenFirstAidKitMedicines/{id}")]
        public async Task<IActionResult> GetUserChosenFirstAidKitMedicines(int id)
        {
            var userMedicines = await _fakRepo.GetUserChosenFirstAidKitMedicines(id);

            return Ok(userMedicines);
            
        }
        [AllowAnonymous]
        [HttpGet("getUserTakenMedicines/{id}")]
        public async Task<IActionResult> GetUserTakenMedicines(int id)
        {
            var userMedicines = await _fakRepo.GetUserTakenMedicines(id);

            return Ok(userMedicines);
            
        }
        [AllowAnonymous]
        [Route("expiredMedicines/{id}")]
        public async Task<IActionResult> GetExpiredMedicines(int id)
        {
            var expiredMedicines = await _fakRepo.GetExpiredMedicines(id);

            return Ok(expiredMedicines);
            
        }

        [AllowAnonymous]
        [Route("getUserFirstAidKits/{id}")]
        public async Task<IActionResult> GetUserFirstAidKits(int id)
        {
            var expiredMedicines = await _fakRepo.GetUserFirstAidKits(id);

            return Ok(expiredMedicines);
            
        }

        


        // POST api/fak
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/fak/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/fak/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
