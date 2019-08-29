using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Supermarket.DataAccess.Interface
{
    public interface IRepository<T> where T : class
    {       
        Task<int> AddAsync(T entity, bool isCommit = true);

        Task<int> AddListAsync(List<T> lists, bool isCommit = true);

        Task<int> DeleteAsync(T entity, bool isCommit = true);

        Task<int> DeleteListAsync(List<T> lists, bool isCommit = true);

        Task<int> DeleteAsync(Expression<Func<T, bool>> query = null, bool isCommit = true);

        Task<int> UpdateAsync(T entity, bool isCommit = true, bool isUpdate = true, params Expression<Func<T, object>>[] propertiesToUpdate);
    
        Task<int> UpdateListAsync(List<T> lists, bool isCommit = true, bool isUpdate = true, params Expression<Func<T, object>>[] propertiesToUpdate);
    
        Task<T> GetAsync(Expression<Func<T, bool>> query = null, bool ignoreQueryFilters = false);

        Task<int> CountAsync(Expression<Func<T, bool>> query = null, bool ignoreQueryFilters = false);

        Task<bool> IsExistAsync(Expression<Func<T, bool>> query = null, bool ignoreQueryFilters = false);

        IQueryable<T> GetAllAsync(Expression<Func<T, bool>> query = null, bool ignoreQueryFilters = false);
    
        IQueryable<T> GetPageAllAsync(int pageIndex, int pageSize, Expression<Func<T, bool>> where = null, string orderExpression = null, bool ignoreQueryFilters = false);
    }
}