#nullable enable

namespace DataAccessLayer.Model
{
    public class Team
    {
        private readonly int _id;
        public Team() { }
        public Team(int id, string country, string alternateName, string fifaCode, int groupId, string groupLetter)
        {
            _id = id;
            Id = id;
            Country = country;
            Alternate_name = alternateName;
            Fifa_code = fifaCode;
            Group_id = groupId;
            Group_letter = groupLetter;
        }

        public int Id { get; set; }
        public string Country { get; set; }
        public string? Alternate_name { get; set; }
        public string Fifa_code { get; set; }
        public int Group_id { get; set; }
        public string Group_letter { get; set; }

        public override bool Equals(object obj) => obj is Team team && Id == team.Id;
        public override int GetHashCode() => _id;
        public override string ToString()
            => $"{Id} {Country} {Alternate_name} {Fifa_code} {Group_id} {Group_letter}";
    }
}
