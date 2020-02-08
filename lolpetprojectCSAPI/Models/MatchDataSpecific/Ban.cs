using System.Text.Json.Serialization;

namespace lolpetprojectCSAPI.Models.MatchDataSpecific
{
    public class Ban
    {
        [JsonPropertyName("pickTurn")]
        public long PickTurn { get; set; }

        [JsonPropertyName("championId")]
        public long ChampionId { get; set; }
    }
}