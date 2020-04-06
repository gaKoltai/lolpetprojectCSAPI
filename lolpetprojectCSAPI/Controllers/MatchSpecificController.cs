using System.Threading.Tasks;
using lolpetprojectCSAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace lolpetprojectCSAPI.Controllers
{
    [ApiController]
    [Route("api/match")]
    public class MatchSpecificController : ControllerBase
    {
        private readonly IMatchSpecificRepository _repository;

        public MatchSpecificController(IMatchSpecificRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{region}/{id}")]
        public async Task<IActionResult> GetMatchDataById(string region, long id)
        {
            var matchSpecific = await _repository.GetMatchSpecificDataAsync(id, region);

            if (matchSpecific == null)
            {
                return BadRequest();
            }
            return Ok(matchSpecific);
        }
    }
}