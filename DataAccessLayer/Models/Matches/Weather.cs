﻿using DataAccessLayer.Models.Matches.Converters;
using DataAccessLayer.Models.Matches.Enums;
using Newtonsoft.Json;

namespace DataAccessLayer.Models.Matches
{
    public class Weather
    {
        [JsonProperty("humidity")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Humidity { get; set; }

        [JsonProperty("temp_celsius")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long TempCelsius { get; set; }

        [JsonProperty("temp_farenheit")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long TempFarenheit { get; set; }

        [JsonProperty("wind_speed")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long WindSpeed { get; set; }

        [JsonProperty("description")]
        [JsonConverter(typeof(WeatherDescriptionConverter))]
        public WeatherDescription WeatherDescription { get; set; }
    }
}
