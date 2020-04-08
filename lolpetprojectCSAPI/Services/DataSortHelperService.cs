using System;
using System.Collections.Generic;
using System.Linq;
using lolpetprojectCSAPI.Interfaces;
using lolpetprojectCSAPI.Models.MatchDataSpecific;

namespace lolpetprojectCSAPI.Services.RiotApiServices
{
    public class DataSortHelperService : IDataSortHelperService
    {

        private Participant GetPlayerStats(List<Participant> participants, long playerChampionId)
        {
            Participant player = null;

            foreach (var participant in participants.Where(participant => participant.ChampionId == playerChampionId))
            {
                player = participant;
            }

            return player;
        }

        private double CalculateKDA(long kills, long deaths, long assists)
        {
            var kda = (double) (kills + assists) / deaths;

            return Math.Round(kda, 2);
        }


        private double CalculateVisionScorePerMin(long visionScore, long gameDuration)
        {
            var gameLengthInMinutes = TimeSpan.FromSeconds(gameDuration).TotalMinutes;
            var rawVisionScore = visionScore / gameLengthInMinutes;

            return Math.Round(rawVisionScore, 2);
        }

        private double CalculateDamagePerMin(long playerDamage, long gameDuration)
        {
            var gameLengthInMinutes = TimeSpan.FromSeconds(gameDuration).TotalMinutes;
            var rawDmgPerMin = playerDamage / gameLengthInMinutes;

            return Math.Round(rawDmgPerMin, 2);
        }

        private double CalculateCsPerMin(long totalCs, long gameDuration)
        {
            var gameLengthInMinutes = TimeSpan.FromSeconds(gameDuration).TotalMinutes;
            var rawCsPerMin = totalCs / gameLengthInMinutes;

            return Math.Round(rawCsPerMin, 2);
        }

        private int CalculatePlayerKillParticipation(List<Participant> teams, long playerKills, long playerAssists,
            long teamId)
        {
            var totalTeamKills = (double) GetPlayerTeamKills(teams, teamId);
            var totalPlayerKills = (double) playerAssists + playerKills;

            if (totalPlayerKills == 0)
            {
                return 0;
            }

            var kpPercent = (totalPlayerKills / totalTeamKills) * 100;

            return Convert.ToInt32(kpPercent);
        }

        private int CalculatePlayerDamagePercent(List<Participant> teams, long playerDamage, long teamId)
        {
            var totalTeamDamage = (double) GetPlayerTeamDamage(teams, teamId);

            if (playerDamage == 0)
            {
                return 0;
            }

            var damagePercent = (playerDamage / totalTeamDamage) * 100;

            return Convert.ToInt32(damagePercent);
        }

        private long GetPlayerTeamDamage(List<Participant> participants, long teamId)
        {
            return participants.Where(participant => participant.TeamId == teamId)
                .Sum(participant => participant.Stats.TotalDamageDealtToChampions);
        }


        private long GetPlayerTeamKills(List<Participant> participants, long teamId)
        {

            return participants.Where(participant => participant.TeamId == teamId)
                .Sum(participant => participant.Stats.Kills);
        }


        private TimeSpan ConvertGameDurationToMinutesAndSeconds(long gameDuration)
        {
            var convertedGameDuration = TimeSpan.FromSeconds(gameDuration);

            return convertedGameDuration;
        }

        private string CalculateApproximateRole(string lane, string role, long queueId)
        {
            if (!IsGameTypeNormal(queueId)) {
                return "FILL";
            }
            else if (lane != "NONE" && lane != "BOTTOM") {
                return lane;
            } 
            else switch (lane)
            {
                case "BOTTOM" when role != "NONE" && role != "SOLO":
                    return role;
                case "NONE" when (role == "DUO" || role == "SOLO"):
                    return "FILL";
                case "NONE" when role != "NONE":
                    return role;
            }
            
            return "FILL";
        }


        private bool IsGameTypeNormal(long queueId)
        {
            return queueId == 420 || queueId == 440 || queueId == 400;
        }


        public SortedMatchData SortMatchData(MatchSpecific matchSpecific, long championId)
        {
            Participant player = GetPlayerStats(matchSpecific.Participants, championId);
            Stats playerStats = player.Stats;
            var minionsKilled = playerStats.TotalMinionsKilled;
            var gameDuration = matchSpecific.GameDuration;
            var kills = playerStats.Kills;
            var assists = playerStats.Assists;
            var deaths = playerStats.Deaths;

            return new SortedMatchData()
            {
                Kda= CalculateKDA(kills, deaths, assists),
                KillParticipation = CalculatePlayerKillParticipation(matchSpecific.Participants, kills, assists, player.TeamId),
                Kills = kills,
                Assists = deaths,
                Deaths = assists,
                GameLength = ConvertGameDurationToMinutesAndSeconds(matchSpecific.GameDuration),
                Win = playerStats.Win,
                MinionsKilled = playerStats.TotalMinionsKilled,
                CsPerMin = CalculateCsPerMin(minionsKilled, gameDuration) ,
                VisionScorePerMin = CalculateVisionScorePerMin(playerStats.VisionScore, gameDuration),
                DamagePerMin = CalculateDamagePerMin(playerStats.TotalDamageDealtToChampions, matchSpecific.GameDuration),
                
                DamagePercentOfTotal = CalculatePlayerDamagePercent(matchSpecific.Participants,
                    playerStats.TotalDamageDealtToChampions, player.TeamId),
                
                QueueId = matchSpecific.QueueId,
                Role = CalculateApproximateRole(player.Timeline.Role, player.Timeline.Lane, matchSpecific.QueueId)
            };
            
        }
    }
}