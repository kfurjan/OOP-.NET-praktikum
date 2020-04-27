using System.Collections.Generic;
using Flurl.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DataAccessLayer.API
{
    public static class FlurlHttpClient
    {
        private static async Task<IEnumerable<dynamic>> GetApiDataAsync(string endpoint) => await endpoint.GetJsonAsync<IEnumerable<dynamic>>();
        public static async Task<IEnumerable<dynamic>> GetJsonDataAsync(string endpoint)
        {
            try
            {
                var apiData = GetApiDataAsync(endpoint);
                var jObjects = await apiData;

                return jObjects;
            }
            
            catch (FlurlHttpException)
            {
                return new List<dynamic>();
            }
        }
    }
}
