using System;
using System.Threading.Tasks;
using lolpetprojectCSAPI.Interfaces;
using lolpetprojectCSAPI.Models.RankingBasic;
using RestSharp;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace lolpetprojectCSAPI.Services.RiotApiServices
{
    public class QueueStatRepository: IQueueStatRepository
    {

        private readonly IApiKeyProvider _apiKeyProvider;
        private readonly IApiRouter _apiRouter;

        public QueueStatRepository(IApiKeyProvider apiKeyProvider, IApiRouter apiRouter)
        {
            _apiKeyProvider = apiKeyProvider;
            _apiRouter = apiRouter;
        }
        
        public async Task<QueueStat[]> GetQueueStatsAsync(string summonerId, string region)
        {
            try
            {
                var client = new RestClient($"https://{_apiRouter.GetRegionLink(region)}.api.riotgames.com/lol/league/v4/entries/by-summoner/" +
                                            $"{summonerId}?api_key={_apiKeyProvider.GetApiKey()}");
                var request = new RestRequest(Method.GET);
                IRestResponse response = await client.ExecuteAsync(request);

                if (response.IsSuccessful)
                {
                    var queueStatArray = JsonSerializer.Deserialize<QueueStat[]>(response.Content);

                    return queueStatArray;
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