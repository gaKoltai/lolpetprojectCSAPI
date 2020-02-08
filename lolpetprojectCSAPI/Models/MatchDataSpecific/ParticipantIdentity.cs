using System.Text.Json.Serialization;

namespace lolpetprojectCSAPI.Models.MatchDataSpecific
{
    public class ParticipantIdentity
    {
        [JsonPropertyName("player")] 
        public Player Player { get; set; }

        [JsonPropertyName("participantId")] 
        public long ParticipantId { get; set; }
    }
}