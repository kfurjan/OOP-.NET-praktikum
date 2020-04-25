using System.Collections.Generic;
using Flurl.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DataAccessLayer.API
{
    public static class FlurlHttpClient
    {
        private const string WOMEN_API_URL = @"https://worldcup.sfg.io/";
        private const string MEN_API_URL = @"https://world-cup-json-2018.herokuapp.com/";
        private const string MATCHES_ENDPOINT = @"matches/";
        private const string TEAMS_ENDPOINT = @"teams/";

        public static async Task<string> GetApiDataAsync(string endpoint) => await endpoint.GetStringAsync();

        public static async Task<IEnumerable<T>> GetSomeClass<T>()
        {
            var apiData = GetApiDataAsync($"{MEN_API_URL}{MATCHES_ENDPOINT}");
            var data = await apiData;

            return JsonConvert.DeserializeObject<IEnumerable<T>>(data);
        }

        //public static async Task<IList<Team>> GetWomenTeamsAsync()
        //{
        //    IList<Team> teams = new List<Team>();
        //    try
        //    {
        //        Task<IList<dynamic>> apiData = GetApiDataAsync($"{WOMEN_API_URL}{TEAMS_ENDPOINT}");
        //        IList<dynamic> teamsData = await apiData;

        //        teamsData.ToList().ForEach(team =>
        //            {
        //                try
        //                {
        //                    teams.Add(new Team(
        //                                (int)team.id,
        //                                (string)team.country,
        //                                (string)team.alternate_name,
        //                                (string)team.fifa_code,
        //                                (int)team.group_id,
        //                                (string)team.group_letter));
        //                }
        //                catch (Exception) { }
        //            });
        //    }
        //    catch (FlurlHttpException) { throw; }

        //    return teams;
        //}

        //public static async Task<IList<Team>> GetMenTeamsAsync()
        //{
        //    IList<Team> teams = new List<Team>();
        //    try
        //    {
        //        Task<IList<dynamic>> apiData = GetApiDataAsync($"{MEN_API_URL}{TEAMS_ENDPOINT}");
        //        IList<dynamic> teamsData = await apiData;

        //        teamsData.ToList().ForEach(team =>
        //        {
        //            try
        //            {
        //                teams.Add(new Team(
        //                            (int)team.id,
        //                            (string)team.country,
        //                            (string)team.alternate_name,
        //                            (string)team.fifa_code,
        //                            (int)team.group_id,
        //                            (string)team.group_letter));
        //            }
        //            catch (Exception) { }
        //        });
        //    }
        //    catch (FlurlHttpException) { throw; }

        //    return teams;
        //}
    }
}
