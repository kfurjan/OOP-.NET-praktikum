using Newtonsoft.Json;

namespace DataAccessLayer.Models
{
    public class Team
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("alternate_name")]
        public dynamic AlternateName { get; set; }

        [JsonProperty("fifa_code")]
        public string FifaCode { get; set; }

        [JsonProperty("group_id")]
        public long GroupId { get; set; }

        [JsonProperty("group_letter")]
        public string GroupLetter { get; set; }

        public override string ToString()
        {
            return $"{Country.ToUpper()} ({FifaCode.ToUpper()})";
        }
    }
}
