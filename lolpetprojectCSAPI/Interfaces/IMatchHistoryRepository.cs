using System.Threading.Tasks;
using lolpetprojectCSAPI.Models.MatchDataBasic;

namespace lolpetprojectCSAPI.Interfaces
{
    public interface IMatchHistoryRepository
    {
        Task<MatchHistory> GetMatchHistoryAsync(string accountId, int startIndex, int endIndex);
    }
}