using System.Text.Json.Serialization;

namespace lolpetprojectCSAPI.Models.MatchDataSpecific
{
    public class Player
    {
        [JsonPropertyName("currentPlatformId")]
        public string CurrentPlatformId { get; set; }

        [JsonPropertyName("summonerName")]
        public string SummonerName { get; set; }

        [JsonPropertyName("matchHistoryUri")]
        public string MatchHistoryUri { get; set; }

        [JsonPropertyName("platformId")]
        public string PlatformId { get; set; }

        [JsonPropertyName("currentAccountId")]
        public string CurrentAccountId { get; set; }

        [JsonPropertyName("profileIcon")]
        public long ProfileIcon { get; set; }

        [JsonPropertyName("summonerId")]
        public string SummonerId { get; set; }

        [JsonPropertyName("accountId")]
        public string AccountId { get; set; }
    }
}