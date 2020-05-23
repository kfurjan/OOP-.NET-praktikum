using DataAccessLayer.Api;
using Newtonsoft.Json;
using RestSharp;
using System.Threading.Tasks;

namespace DataAccessLayer.Json
{
    public class JsonApi : IApi
    {
        public Task<T> GetDataAsync<T>(string endpoint)
        {
            return Task.Run(() =>
                JsonConvert.DeserializeObject<T>(new RestClient(endpoint).Execute<T>(new RestRequest()).Content));
        }
    }
}
