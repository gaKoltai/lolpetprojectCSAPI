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

        private IApiKeyProvider _apiKeyProvider;

        public QueueStatRepository(IApiKeyProvider apiKeyProvider)
        {
            _apiKeyProvider = apiKeyProvider;
        }
        
        public async Task<QueueStat[]> GetQueueStatsAsync(string summonerId)
        {
            try
            {
                var client = new RestClient($"https://euw1.api.riotgames.com/lol/league/v4/entries/by-summoner/" +
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