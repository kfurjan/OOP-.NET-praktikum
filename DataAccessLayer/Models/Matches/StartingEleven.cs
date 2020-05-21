using DataAccessLayer.Models.Matches.Enums;
using Newtonsoft.Json;

namespace DataAccessLayer.Models.Matches
{
    public class StartingEleven
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("captain")]
        public bool Captain { get; set; }

        [JsonProperty("shirt_number")]
        public long ShirtNumber { get; set; }

        [JsonProperty("position")]
        public Position Position { get; set; }
    }
}
