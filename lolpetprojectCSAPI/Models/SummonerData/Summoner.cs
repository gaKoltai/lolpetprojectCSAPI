using System.Text.Json.Serialization;

namespace lolpetprojectCSAPI.Models.SummonerData
{
    public class Summoner
    {
        [JsonPropertyName("profileIconId")]
        public int ProfileIconId { get; set; }
        
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        [JsonPropertyName("puuid")]
        public string Puuid { get; set; }
        
        [JsonPropertyName("summonerLevel")]
        public int SummonerLevel { get; set; }
        
        [JsonPropertyName("accountId")]
        public string AccountId { get; set; }
        
        [JsonPropertyName("id")]
        public string Id { get; set; }
        
        [JsonPropertyName("revisionDate")]
        public long RevisionDate { get; set; }
    }
}