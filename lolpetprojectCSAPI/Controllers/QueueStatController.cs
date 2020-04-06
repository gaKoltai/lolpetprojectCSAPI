using System.Threading.Tasks;
using lolpetprojectCSAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace lolpetprojectCSAPI.Controllers
{
    [ApiController]
    [Route("api/queues")]
    public class QueueStatController : ControllerBase
    {

        private readonly IQueueStatRepository _repository;

        public QueueStatController(IQueueStatRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{region}/{summonerId}")]
        public async Task<IActionResult> GetQueueStats(string region, string summonerId)
        {
            var matchSpecific = await _repository.GetQueueStatsAsync(summonerId, region);

            if (matchSpecific == null)
            {
                return BadRequest();
            }
            return Ok(matchSpecific);
        }
    }
}