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

        // GET api/values/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserMedicines(int id)
        {
            var userMedicines = await _fakRepo.GetUserMedicines(id);

            return Ok(userMedicines);
            
        }

        


        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
