using DataAccessLayer.Model;
using Flurl.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.API
{
    public static class FlurlHttpClient
    {
        private const string API_URL = "https://worldcup.sfg.io/";
        private const string MATCHES_ENDPOINT = "matches/";
        private const string TEAMS_ENDPOINT = "teams/";

        private static async Task<IList<dynamic>> GetApiDataAsync(string endpoint) => await endpoint.GetJsonAsync<IList<dynamic>>();

        public static async Task<IList<Team>> GetListAllTeamsAsync()
        {
            Task<IList<dynamic>> apiData = GetApiDataAsync($"{API_URL}{TEAMS_ENDPOINT}");
            IList<dynamic> teamsData = await apiData;

            IList<Team> teams = new List<Team>();
            teamsData.ToList().ForEach(team =>
            {
                try
                {
                    teams.Add(new Team(
                                (int)team.id,
                                (string)team.country,
                                (string)team.alternate_name,
                                (string)team.fifa_code,
                                (int)team.group_id,
                                (string)team.group_letter));
                }
                catch (FlurlHttpException) { }
            });

            return teams;
        }
    }
}
