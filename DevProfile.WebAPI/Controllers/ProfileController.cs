using DevProfile.Application.DTO;
using DevProfile.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevProfile.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileAppService profileAppService;

        public ProfileController(IProfileAppService profileAppService)
        {
            this.profileAppService = profileAppService;
        }

        // GET api/profile
        [HttpGet]
        public IActionResult Get()
        {
            var profiles = profileAppService.GetAll();
            return Ok(profiles);
        }

        // GET api/profile/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var profile = profileAppService.GetByDeveloperId(id);
            return Ok(profile);
        }

        // POST api/profile
        [HttpPost]
        public void Post([FromBody] ProfileDTO profileDTO)
        {
            profileAppService.SaveNewProfile(profileDTO);
        }

        // PUT api/profile/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ProfileDTO profileDTO)
        {
        }

        // DELETE api/profile/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            profileAppService.DeleteProfile(id);
        }
    }
}
