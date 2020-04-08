using System;
using System.Text.Json;
using System.Threading.Tasks;
using lolpetprojectCSAPI.Interfaces;
using lolpetprojectCSAPI.Models.MatchDataSpecific;

using RestSharp;

namespace lolpetprojectCSAPI.Services.RiotApiServices
{
    public class MatchSpecificRepository : IMatchSpecificRepository
    {

        private readonly IApiKeyProvider _apiKeyProvider;
        private readonly IApiRouter _apiRouter;
        private readonly IDataSortHelperService _dataSortHelper;

        public MatchSpecificRepository(IApiKeyProvider apiKeyProvider, IApiRouter apiRouter, IDataSortHelperService dataSortHelper)
        {
            _apiKeyProvider = apiKeyProvider;
            _apiRouter = apiRouter;
            _dataSortHelper = dataSortHelper;
        }
        
        public async Task<SortedMatchData> GetMatchSpecificDataAsync(long matchId, string region, long championId)
        {
            
            try
            {
                var client = new RestClient($"https://{_apiRouter.GetRegionLink(region)}.api.riotgames.com/lol/match/v4/matches/{matchId}?api_key={_apiKeyProvider.GetApiKey()}");
                var request = new RestRequest(Method.GET);
                IRestResponse response = await client.ExecuteAsync(request);

                if (response.IsSuccessful)
                {
                    var matchSpecific = JsonSerializer.Deserialize<MatchSpecific>(response.Content);

                    var sortedMatchData = _dataSortHelper.SortMatchData(matchSpecific, championId);
                    
                    return sortedMatchData;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.StackTrace);
                throw;
            }

            return null;
        }
    }
}