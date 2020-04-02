using System.Threading.Tasks;
using lolpetprojectCSAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace lolpetprojectCSAPI.Controllers
{
    [ApiController]
    [Route("api/match-history")]
    public class MatchHistoryController : ControllerBase
    {

        private readonly IMatchHistoryRepository _repository;

        public MatchHistoryController(IMatchHistoryRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{accountId}")]
        public async Task<IActionResult> GetMatchHistory(string accountId)
        {
            var matchHistory = await _repository.GetMatchHistoryAsync(accountId, 0, 10);
            if (matchHistory == null)
            {
                return BadRequest();
            }
            return Ok(matchHistory);
        }
    }
}