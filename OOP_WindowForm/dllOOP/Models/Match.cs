﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using dllOOOP.Models;
//
//    var match = Match.FromJson(jsonString);

namespace dllOOOP.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using dllOOP.Models;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Match
    {
        [JsonProperty("venue")]
        public string Venue { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("attendance")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Attendance { get; set; }

        [JsonProperty("home_team_country")]
        public string HomeTeamCountry { get; set; }

        [JsonProperty("away_team_country")]
        public string AwayTeamCountry { get; set; }

        [JsonProperty("home_team_statistics")]
        public TeamStatistics HomeTeamStatistics { get; set; }

        [JsonProperty("away_team_statistics")]
        public TeamStatistics AwayTeamStatistics { get; set; }

    }

    public partial class TeamStatistics
    {
        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("starting_eleven")]
        public List<Player> StartingEleven { get; set; }

        [JsonProperty("substitutes")]
        public List<Player> Substitutes { get; set; }
    }


    [Serializable]
    public enum Position { Defender, Forward, Goalie, Midfield };

    public partial class Match
    {
        public static Match FromJson(string json) => JsonConvert.DeserializeObject<Match>(json, dllOOOP.Models.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Match self) => JsonConvert.SerializeObject(self, dllOOOP.Models.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                PositionConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }

    internal class PositionConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Position) || t == typeof(Position?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "Defender":
                    return Position.Defender;
                case "Forward":
                    return Position.Forward;
                case "Goalie":
                    return Position.Goalie;
                case "Midfield":
                    return Position.Midfield;
            }
            throw new Exception("Cannot unmarshal type Position");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Position)untypedValue;
            switch (value)
            {
                case Position.Defender:
                    serializer.Serialize(writer, "Defender");
                    return;
                case Position.Forward:
                    serializer.Serialize(writer, "Forward");
                    return;
                case Position.Goalie:
                    serializer.Serialize(writer, "Goalie");
                    return;
                case Position.Midfield:
                    serializer.Serialize(writer, "Midfield");
                    return;
            }
            throw new Exception("Cannot marshal type Position");
        }

        public static readonly PositionConverter Singleton = new PositionConverter();
    }
}
