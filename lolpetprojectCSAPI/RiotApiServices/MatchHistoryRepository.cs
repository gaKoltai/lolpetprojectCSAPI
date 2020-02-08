using System;
using System.Text.Json;
using System.Threading.Tasks;
using lolpetprojectCSAPI.Interfaces;
using lolpetprojectCSAPI.Models.MatchDataBasic;
using lolpetprojectCSAPI.StaticUtil;
using RestSharp;

namespace lolpetprojectCSAPI.RiotApiServices
{
    public class MatchHistoryRepository : IMatchHistoryRepository
    {
        private readonly string _apiKey = Util.GetApiKey();
        
        public async Task<MatchHistory> GetMatchHistoryAsync(string accountId, int startIndex, int endIndex)
        {
            try
            {
                var client = new RestClient($"https://euw1.api.riotgames.com/lol/match/v4/matchlists/" +
                                            $"by-account/{accountId}?endIndex={endIndex}&beginIndex={startIndex}" +
                                            $"&api_key={_apiKey}");
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