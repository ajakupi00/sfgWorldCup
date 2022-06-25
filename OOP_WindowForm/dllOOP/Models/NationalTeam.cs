﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using dllOOOP.Models;
//
//    var nationalTeam = NationalTeam.FromJson(jsonString);

namespace dllOOP.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    [Serializable]
    public partial class NationalTeam
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("fifa_code")]
        public string FifaCode { get; set; }

        [JsonProperty("group_id")]
        public long GroupId { get; set; }

        [JsonProperty("group_letter")]
        public string GroupLetter { get; set; }

        [JsonProperty("wins")]
        public long Wins { get; set; }

        [JsonProperty("draws")]
        public long Draws { get; set; }

        [JsonProperty("losses")]
        public long Losses { get; set; }

        [JsonProperty("games_played")]
        public long GamesPlayed { get; set; }

        [JsonProperty("points")]
        public long Points { get; set; }

        [JsonProperty("goals_for")]
        public long GoalsFor { get; set; }

        [JsonProperty("goals_against")]
        public long GoalsAgainst { get; set; }

        [JsonProperty("goal_differential")]
        public long GoalDifferential { get; set; }

        public override bool Equals(object obj)
        {
            return obj is NationalTeam team &&
                   FifaCode == team.FifaCode;
        }

        public override int GetHashCode()
        {
            return FifaCode.GetHashCode();
        }

        public override string ToString() => $"{Country} ({FifaCode})";
    }

    
}
