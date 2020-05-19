using System.Threading.Tasks;

namespace DataAccessLayer.Api
{
    public interface IApi
    {
        public Task<T> GetData<T>(string endpoint);
    }
}
