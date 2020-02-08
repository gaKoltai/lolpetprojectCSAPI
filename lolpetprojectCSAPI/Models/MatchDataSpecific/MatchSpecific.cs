using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace lolpetprojectCSAPI.Models.MatchDataSpecific
{
    public class MatchSpecific
    {
        [JsonPropertyName("seasonId")]
            public long SeasonId { get; set; }

            [JsonPropertyName("queueId")]
            public long QueueId { get; set; }

            [JsonPropertyName("gameId")]
            public long GameId { get; set; }

            [JsonPropertyName("participantIdentities")]
            public List<ParticipantIdentity> ParticipantIdentities { get; set; }

            [JsonPropertyName("gameVersion")]
            public string GameVersion { get; set; }

            [JsonPropertyName("platformId")]
            public string PlatformId { get; set; }

            [JsonPropertyName("gameMode")]
            public string GameMode { get; set; }

            [JsonPropertyName("mapId")]
            public long MapId { get; set; }

            [JsonPropertyName("gameType")]
            public string GameType { get; set; }

            [JsonPropertyName("teams")]
            public List<Team> Teams { get; set; }

            [JsonPropertyName("participants")]
            public List<Participant> Participants { get; set; }

            [JsonPropertyName("gameDuration")]
            public long GameDuration { get; set; }

            [JsonPropertyName("gameCreation")]
            public long GameCreation { get; set; }
        

    }
}