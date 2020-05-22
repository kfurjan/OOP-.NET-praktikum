namespace DataAccessLayer.Utils
{
    public static class EndpointBuilder
    {
        private const string MALE = "https://world-cup-json-2018.herokuapp.com/";
        private const string FEMALE = "https://worldcup.sfg.io/";

        private static string GetTeamGender(string gender)
        {
            return gender.ToLower() switch
            {
                "male" => MALE,
                "female" => FEMALE,
                _ => string.Empty
            };
        }
        public static string GetTeamsEndpoint(string gender)
        {
            return $"{GetTeamGender(gender)}/teams";
        }
    }
}
