using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace lolpetprojectCSAPI.Models.MatchDataBasic
{
    
    public class MatchHistory
    {
        [JsonPropertyName("matches")]
        public List<Match> Matches { get; set; }
        [JsonPropertyName("endIndex")]
        public int EndIndex { get; set; }
        [JsonPropertyName("startIndex")]
        public int StartIndex { get; set; }
        [JsonPropertyName("totalGames")]
        public int TotalGames { get; set; }
    }
}