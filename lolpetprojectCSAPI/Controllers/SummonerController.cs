using System.Threading.Tasks;
using lolpetprojectCSAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace lolpetprojectCSAPI.Controllers
{
    [ApiController]
    [Route("api/summoner")]
    public class SummonerController : ControllerBase
    {
        private readonly ISummonerRepository _repository;

        public SummonerController(ISummonerRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{region}/{name}")]
        public async Task<IActionResult> GetSummonerByName(string region, string name)
        {
            var summoner = await _repository.GetSummonerDataAsync(name, region);

            if (summoner == null) return NotFound();

            return Ok(summoner);
        }
    }
}