using System.Threading.Tasks;

namespace DataAccessLayer.Api
{
    public interface IApi
    {
        public Task<T> GetDataAsync<T>(string endpoint);
    }
}
