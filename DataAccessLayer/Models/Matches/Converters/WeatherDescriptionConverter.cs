using DataAccessLayer.Models.Matches.Enums;
using Newtonsoft.Json;
using System;

namespace DataAccessLayer.Models.Matches.Converters
{
    class WeatherDescriptionConverter : JsonConverter
    {
        public override bool CanConvert(Type t)
        {
            return t == typeof(WeatherDescription) || t == typeof(WeatherDescription?);
        }

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "Clear Night":
                    return WeatherDescription.ClearNight;
                case "Cloudy":
                    return WeatherDescription.Cloudy;
                case "Partly Cloudy":
                    return WeatherDescription.PartlyCloudy;
                case "Partly Cloudy Night":
                    return WeatherDescription.PartlyCloudyNight;
                case "Sunny":
                    return WeatherDescription.Sunny;
            }
            throw new Exception("Cannot un-marshal type Description");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (WeatherDescription)untypedValue;
            switch (value)
            {
                case WeatherDescription.ClearNight:
                    serializer.Serialize(writer, "Clear Night");
                    return;
                case WeatherDescription.Cloudy:
                    serializer.Serialize(writer, "Cloudy");
                    return;
                case WeatherDescription.PartlyCloudy:
                    serializer.Serialize(writer, "Partly Cloudy");
                    return;
                case WeatherDescription.PartlyCloudyNight:
                    serializer.Serialize(writer, "Partly Cloudy Night");
                    return;
                case WeatherDescription.Sunny:
                    serializer.Serialize(writer, "Sunny");
                    return;
            }
            throw new Exception("Cannot marshal type Description");
        }

        public static readonly WeatherDescriptionConverter Singleton = new WeatherDescriptionConverter();
    }
}
