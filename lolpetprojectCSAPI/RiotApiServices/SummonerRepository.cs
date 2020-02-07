﻿using System;
using System.Text.Json;
using System.Threading.Tasks;
using lolpetprojectCSAPI.Interfaces;
using lolpetprojectCSAPI.Models.SummonerData;
using lolpetprojectCSAPI.StaticUtil;
using RestSharp;

namespace lolpetprojectCSAPI.RiotApiServices
{
    public class SummonerRepository : ISummonerRepository
    {
        private readonly string _apiKey = Util.GetApiKey();

        public async Task<Summoner> GetSummonerDataAsync(string name)
        {
            try
            {
                var client = new RestClient($"https://euw1.api.riotgames.com/lol/summoner/v4/summoners/by-name/{name}" +
                                            $"?api_key={_apiKey}");
                var request = new RestRequest(Method.GET);
                IRestResponse response = await client.ExecuteAsync(request);

                if (response.IsSuccessful)
                {
                    var summoner = JsonSerializer.Deserialize<Summoner>(response.Content);

                    return summoner;
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