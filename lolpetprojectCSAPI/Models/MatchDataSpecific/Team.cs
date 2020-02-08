using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace lolpetprojectCSAPI.Models.MatchDataSpecific
{
    public class Team
    {
        [JsonPropertyName("firstDragon")]
        public bool FirstDragon { get; set; }

        [JsonPropertyName("bans")]
        public List<Ban> Bans { get; set; }

        [JsonPropertyName("firstInhibitor")]
        public bool FirstInhibitor { get; set; }

        [JsonPropertyName("win")]
        public string Win { get; set; }

        [JsonPropertyName("firstRiftHerald")]
        public bool FirstRiftHerald { get; set; }

        [JsonPropertyName("firstBaron")]
        public bool FirstBaron { get; set; }

        [JsonPropertyName("baronKills")]
        public long BaronKills { get; set; }

        [JsonPropertyName("riftHeraldKills")]
        public long RiftHeraldKills { get; set; }

        [JsonPropertyName("firstBlood")]
        public bool FirstBlood { get; set; }

        [JsonPropertyName("teamId")]
        public long TeamId { get; set; }

        [JsonPropertyName("firstTower")]
        public bool FirstTower { get; set; }

        [JsonPropertyName("vilemawKills")]
        public long VilemawKills { get; set; }

        [JsonPropertyName("inhibitorKills")]
        public long InhibitorKills { get; set; }

        [JsonPropertyName("towerKills")]
        public long TowerKills { get; set; }

        [JsonPropertyName("dominionVictoryScore")]
        public long DominionVictoryScore { get; set; }

        [JsonPropertyName("dragonKills")]
        public long DragonKills { get; set; }
    }
}