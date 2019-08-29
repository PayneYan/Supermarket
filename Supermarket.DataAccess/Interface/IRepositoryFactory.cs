using Supermarket.DataAccess.Data;

namespace Supermarket.DataAccess.Interface
{
    public interface IRepositoryFactory
    {
         IRepository<T> CreateRepository<T>(SupermarketContext dbContext) where T : class;
    }
}