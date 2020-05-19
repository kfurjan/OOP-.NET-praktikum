using DataAccessLayer.Json;

namespace DataAccessLayer.Api
{
    public static class ApiFactory
    {
        public static IApi GetApi()
        {
            return new JsonApi();
        }
    }
}
