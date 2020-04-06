using System.Threading.Tasks;
using lolpetprojectCSAPI.Models.SummonerData;

namespace lolpetprojectCSAPI.Interfaces
{
    public interface ISummonerRepository
    {
        Task<Summoner> GetSummonerDataAsync(string name, string region);
    }
}