using DataAccessLayer.Api;
using Newtonsoft.Json;
using RestSharp;
using System.Threading.Tasks;

namespace DataAccessLayer.Json
{
    public class JsonApi : IApi
    {
        public Task<T> GetData<T>(string endpoint)
        {
            return Task.Run(() =>
            {
                IRestResponse<T> result = new RestClient(endpoint).Execute<T>(new RestRequest());
                return JsonConvert.DeserializeObject<T>(result.Content);
            });
        }
    }
}
