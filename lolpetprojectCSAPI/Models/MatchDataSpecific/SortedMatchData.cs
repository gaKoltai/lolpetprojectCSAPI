using System;
using Microsoft.AspNetCore.Identity;

namespace lolpetprojectCSAPI.Models.MatchDataSpecific
{
    public class SortedMatchData
    {

        public double Kda { get; set; }
        public int KillParticipation { get; set; }
        public long Kills { get; set; }
        public long Assists { get; set; }
        public long Deaths { get; set; }
        public TimeSpan GameLength { get; set; }
        public bool Win { get; set; }
        public long MinionsKilled { get; set; }
        public double CsPerMin { get; set; }
        public double VisionScorePerMin { get; set; }
        public double DamagePerMin { get; set; }
        public decimal DamagePercentOfTotal { get; set; }
        public long QueueId { get; set; }
        
        public string Role { get; set; }
        
        public long ChampionId { get; set; }

        public long GameId { get; set; }
    }
}