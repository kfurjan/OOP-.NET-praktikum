namespace DataAccessLayer.Model
{
    public class Team
    {
        public Team() { }
        public Team(int id, string country, string alternateName, string fifaCode, int groupId, string groupLetter)
        {
            Id = id;
            Country = country;
            AlternateName = alternateName;
            FifaCode = fifaCode;
            GroupId = groupId;
            GroupLetter = groupLetter;
        }

        public int Id { get; set; }
        public string Country { get; set; }
        public string AlternateName { get; set; }
        public string FifaCode { get; set; }
        public int GroupId { get; set; }
        public string GroupLetter { get; set; }

        public override bool Equals(object obj) => obj is Team team ? Id == team.Id : false;
        public override int GetHashCode() => Id;
        public override string ToString()
            => $"{Id} {Country} {AlternateName} {FifaCode} {GroupId} {GroupLetter}";
    }
}
