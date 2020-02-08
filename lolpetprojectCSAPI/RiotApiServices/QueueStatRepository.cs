using System;
using System.Threading.Tasks;
using lolpetprojectCSAPI.Interfaces;
using lolpetprojectCSAPI.Models.RankingBasic;
using lolpetprojectCSAPI.StaticUtil;
using RestSharp;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace lolpetprojectCSAPI.RiotApiServices
{
    public class QueueStatRepository: IQueueStatRepository
    {

        private readonly string _apiKey = Util.GetApiKey();
        
        public async Task<QueueStat[]> GetQueueStatsAsync(string summonerId)
        {
            try
            {
                var client = new RestClient($"https://euw1.api.riotgames.com/lol/league/v4/entries/by-summoner/" +
                                            $"{summonerId}?api_key={_apiKey}");
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