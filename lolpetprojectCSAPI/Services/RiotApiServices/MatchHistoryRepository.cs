using System;
using System.Text.Json;
using System.Threading.Tasks;
using lolpetprojectCSAPI.Interfaces;
using lolpetprojectCSAPI.Models.MatchDataBasic;
using RestSharp;

namespace lolpetprojectCSAPI.Services.RiotApiServices
{
    public class MatchHistoryRepository : IMatchHistoryRepository
    {
        private readonly IApiKeyProvider _apiKeyProvider;
        private readonly IApiRouter _apiRouter;

        public MatchHistoryRepository(IApiKeyProvider apiKeyProvider, IApiRouter apiRouter)
        {
            _apiKeyProvider = apiKeyProvider;
            _apiRouter = apiRouter;
        }
        
        
        public async Task<MatchHistory> GetMatchHistoryAsync(string accountId, int startIndex, int endIndex, string region)
        {
            try
            {
                var client = new RestClient($"https://{_apiRouter.GetRegionLink(region)}.api.riotgames.com/lol/match/v4/matchlists/" +
                                            $"by-account/{accountId}?endIndex={endIndex}&beginIndex={startIndex}" +
                                            $"&api_key={_apiKeyProvider.GetApiKey()}");
                var request = new RestRequest(Method.GET);
                IRestResponse response = await client.ExecuteAsync(request);

                if (response.IsSuccessful)
                {
                    var matchHistory = JsonSerializer.Deserialize<MatchHistory>(response.Content);

                    return matchHistory;
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