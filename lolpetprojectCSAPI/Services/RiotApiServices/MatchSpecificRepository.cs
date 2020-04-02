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

        private IApiKeyProvider _apiKeyProvider;

        public MatchSpecificRepository(IApiKeyProvider apiKeyProvider)
        {
            _apiKeyProvider = apiKeyProvider;
        }
        
        public async Task<MatchSpecific> GetMatchSpecificDataAsync(long matchId)
        {
            
            try
            {
                var client = new RestClient($"https://euw1.api.riotgames.com/lol/match/v4/matches/{matchId}?api_key={_apiKeyProvider.GetApiKey()}");
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