using lolpetprojectCSAPI.Models.MatchDataSpecific;

namespace lolpetprojectCSAPI.Interfaces
{
    public interface IDataSortHelperService
    {
        SortedMatchData SortMatchData(MatchSpecific matchSpecific, long championId);
    }
}