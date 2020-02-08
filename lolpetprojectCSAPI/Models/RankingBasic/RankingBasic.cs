using System.Text.Json.Serialization;

namespace lolpetprojectCSAPI.Models.RankingBasic
{
    public class QueueStat
    {
        [JsonPropertyName("queueType")] public string QueueType { get; set; }

        [JsonPropertyName("summonerName")] public string SummonerName { get; set; }

        [JsonPropertyName("hotStreak")] public bool HotStreak { get; set; }

        [JsonPropertyName("wins")] public long Wins { get; set; }

        [JsonPropertyName("veteran")] public bool Veteran { get; set; }

        [JsonPropertyName("losses")] public long Losses { get; set; }

        [JsonPropertyName("rank")] public string Rank { get; set; }

        [JsonPropertyName("tier")] public string Tier { get; set; }

        [JsonPropertyName("inactive")] public bool Inactive { get; set; }

        [JsonPropertyName("freshBlood")] public bool FreshBlood { get; set; }

        [JsonPropertyName("leagueId")] public string LeagueId { get; set; }

        [JsonPropertyName("summonerId")] public string SummonerId { get; set; }

        [JsonPropertyName("leaguePoints")] public long LeaguePoints { get; set; }
    }
}