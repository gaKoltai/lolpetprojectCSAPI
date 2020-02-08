using System.Text.Json.Serialization;

namespace lolpetprojectCSAPI.Models.MatchDataSpecific
{
    public class Participant
    {
        [JsonPropertyName("spell1Id")]
        public long Spell1Id { get; set; }

        [JsonPropertyName("participantId")]
        public long ParticipantId { get; set; }

        [JsonPropertyName("timeline")]
        public Timeline Timeline { get; set; }

        [JsonPropertyName("spell2Id")]
        public long Spell2Id { get; set; }

        [JsonPropertyName("teamId")]
        public long TeamId { get; set; }

        [JsonPropertyName("stats")]
        public Stats Stats { get; set; }

        [JsonPropertyName("championId")]
        public long ChampionId { get; set; }
    }
}