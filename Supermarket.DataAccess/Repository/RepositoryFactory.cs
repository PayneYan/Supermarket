using Supermarket.DataAccess.Data;
using Supermarket.DataAccess.Interface;

namespace Supermarket.DataAccess.Repository
{
    public class RepositoryFactory : IRepositoryFactory
    {
        public IRepository<T> CreateRepository<T>(SupermarketContext dbContext) where T : class
        {
            return new Repository<T>(dbContext);
        }
    }
}