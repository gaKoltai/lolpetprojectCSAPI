using System;
using System.Text.Json;
using System.Threading.Tasks;
using lolpetprojectCSAPI.Interfaces;
using lolpetprojectCSAPI.Models.MatchDataBasic;
using lolpetprojectCSAPI.Models.MatchDataSpecific;
using lolpetprojectCSAPI.StaticUtil;
using RestSharp;

namespace lolpetprojectCSAPI.RiotApiServices
{
    public class MatchSpecificRepository : IMatchSpecificRepository
    {

        private readonly string _apiKey = Util.GetApiKey();
        
        public async Task<MatchSpecific> GetMatchSpecificDataAsync(long matchId)
        {
            
            try
            {
                var client = new RestClient($"https://euw1.api.riotgames.com/lol/match/v4/matches/{matchId}?api_key={_apiKey}");
                var request = new RestRequest(Method.GET);
                IRestResponse response = await client.ExecuteAsync(request);

                if (response.IsSuccessful)
                {
                    var matchSpecific = JsonSerializer.Deserialize<MatchSpecific>(response.Content);
                    
                    return matchSpecific;
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