using System.Threading.Tasks;
using lolpetprojectCSAPI.Models.MatchDataSpecific;

namespace lolpetprojectCSAPI.Interfaces
{
    public interface IMatchSpecificRepository
    {
        Task<MatchSpecific> GetMatchSpecificDataAsync(long matchId, string region);
    }
}