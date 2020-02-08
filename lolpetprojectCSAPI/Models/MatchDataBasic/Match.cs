﻿using System.Text.Json.Serialization;

 namespace lolpetprojectCSAPI.Models.MatchDataBasic
{
    public class Match
    {
        [JsonPropertyName("lane")]
        public string Lane { get; set; }
        [JsonPropertyName("gameId")]
        public object GameId { get; set; }
        [JsonPropertyName("champion")]
        public int Champion { get; set; }
        [JsonPropertyName("platformId")]
        public string PlatformId { get; set; }
        [JsonPropertyName("timeStamp")]
        public object Timestamp { get; set; }
        [JsonPropertyName("queue")]
        public int Queue { get; set; }
        [JsonPropertyName("role")]
        public string Role { get; set; }
        [JsonPropertyName("season")]
        public int Season { get; set; }
    }
}