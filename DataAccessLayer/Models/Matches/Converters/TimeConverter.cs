﻿using DataAccessLayer.Models.Matches.Enums;
using Newtonsoft.Json;
using System;

namespace DataAccessLayer.Models.Matches.Converters
{
    class TimeConverter : JsonConverter
    {
        public override bool CanConvert(Type t)
        {
            return t == typeof(Time) || t == typeof(Time?);
        }

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "full-time")
            {
                return Time.FullTime;
            }
            throw new Exception("Cannot un-marshal type Time");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Time)untypedValue;
            if (value == Time.FullTime)
            {
                serializer.Serialize(writer, "full-time");
                return;
            }
            throw new Exception("Cannot marshal type Time");
        }

        public static readonly TimeConverter Singleton = new TimeConverter();
    }
}