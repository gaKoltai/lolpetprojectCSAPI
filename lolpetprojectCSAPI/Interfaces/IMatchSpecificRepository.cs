using System.Threading.Tasks;
using lolpetprojectCSAPI.Models.MatchDataSpecific;

namespace lolpetprojectCSAPI.Interfaces
{
    public interface IMatchSpecificRepository
    {
        Task<SortedMatchData> GetMatchSpecificDataAsync(long matchId, string region, long championId);
    }
}