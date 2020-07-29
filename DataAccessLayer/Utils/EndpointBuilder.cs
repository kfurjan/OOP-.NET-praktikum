namespace DataAccessLayer.Utils
{
    public static class EndpointBuilder
    {
        private const string Male = @"https://world-cup-json-2018.herokuapp.com";
        private const string Female = @"https://worldcup.sfg.io";

        private static string GetTeamGender(string gender)
        {
            return gender.ToLower() switch
            {
                "male" => Male,
                "female" => Female,
                _ => string.Empty
            };
        }

        public static string GetTeamsEndpoint(string gender) => $@"{GetTeamGender(gender)}/teams";

        public static string GetTeamResultsEndpoint(string gender) => $@"{GetTeamsEndpoint(gender)}/results";

        public static string GetMatchesEndpoint(string gender) => $@"{GetTeamGender(gender)}/matches";
    }
}
