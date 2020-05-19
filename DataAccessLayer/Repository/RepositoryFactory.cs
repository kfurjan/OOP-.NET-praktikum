using DataAccessLayer.Filesystem;

namespace DataAccessLayer.Repository
{
    public static class RepositoryFactory
    {
        public static IRepository GetRepository()
        {
            return new FileRepository();
        }
    }
}
