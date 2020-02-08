using System.Threading.Tasks;
using lolpetprojectCSAPI.Models.RankingBasic;

namespace lolpetprojectCSAPI.Interfaces
{
    public interface IQueueStatRepository
    {
        Task<QueueStat[]> GetQueueStatsAsync(string summonerId);
    }
}