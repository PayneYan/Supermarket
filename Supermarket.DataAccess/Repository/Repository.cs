using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Supermarket.DataAccess.Data;
using Supermarket.DataAccess.Interface;

namespace Supermarket.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        
        private readonly SupermarketContext _dbContext;
        public Repository(SupermarketContext dbContext)
        {
            this._dbContext = dbContext;
        }

         #region ====================新增======================
        /// <summary>
        /// 增加一条记录(异步方式)
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="isCommit">是否提交</param>
        /// <returns></returns>
        public Task<int> AddAsync(T entity, bool isCommit = true)
        {
            if (entity == null)
            {
                return Task.Run(() => 0);
            }
            _dbContext.Set<T>().Add(entity);
            return isCommit ? _dbContext.SaveChangesAsync() : Task.Run(() => 0);
        }

        /// <summary>
        /// 增加多条数据，同一模型(异步方式)
        /// </summary>
        /// <param name="list">集合</param>
        /// <param name="isCommit">是否提交</param>
        /// <returns></returns>
        public Task<int> AddListAsync(List<T> lists, bool isCommit = true)
        {
            if (lists == null || lists.Count <= 0)
            {
                return Task.Run(() => 0);
            }
            _dbContext.Set<T>().AddRange(lists);
            return isCommit ? _dbContext.SaveChangesAsync() : Task.Run(() => 0);
        }
        #endregion

        #region ====================删除======================
        /// <summary>
        /// 删除一条数据(异步方式)
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="isCommit">是否提交</param>
        /// <returns></returns>
        public Task<int> DeleteAsync(T entity, bool isCommit = true)
        {
            if (entity == null)
            {
                return Task.Run(() => 0);
            }
            _dbContext.Set<T>().Remove(entity);
            return isCommit ? _dbContext.SaveChangesAsync() : Task.Run(() => 0);
        }

        /// <summary>
        /// 删除多条数据，同一模型（异步方式）
        /// </summary>
        /// <param name="list">集合</param>
        /// <param name="IsCommit">是否提交</param>
        /// <returns></returns>
        public Task<int> DeleteListAsync(List<T> lists, bool isCommit = true)
        {
            if (lists == null || lists.Count <= 0)
            {
                return Task.Run(() => 0);
            }
            _dbContext.Set<T>().RemoveRange(lists);
            return isCommit ? _dbContext.SaveChangesAsync() : Task.Run(() => 0);
        }

        /// <summary>
        /// 通过Lamda表达式，删除一条或多条数据（不传递条件则直接清空库）（异步方式）
        /// </summary>
        /// <param name="query">查询条件(Lambda表达式)</param>
        /// <param name="IsCommit">是否提交</param>
        /// <returns></returns>
        public Task<int> DeleteAsync(Expression<Func<T, bool>> query = null, bool isCommit = true)
        {
            IQueryable<T> queryAble = (query == null) ? _dbContext.Set<T>().AsNoTracking().IgnoreQueryFilters() : _dbContext.Set<T>().AsNoTracking().Where(query).IgnoreQueryFilters();
            List<T> lists = queryAble.ToList();

            if (lists == null || lists.Count <= 0)
            {
                return Task.Run(() => 0);
            }

            _dbContext.Set<T>().RemoveRange(lists);
            return isCommit ? _dbContext.SaveChangesAsync() : Task.Run(() => 0);
        }
        #endregion

        #region ====================修改======================
        /// <summary>
        /// 修改一条数据(异步方式)
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="isCommit">是否提交(默认提交)</param>
        /// <param name="isUpdate">更新方式(默认true),如果传递true，则后面传递的参数更新，如果传递false，则后面传递的参数不更新</param>
        /// <param name="propertiesToUpdate">更新字段</param>
        public Task<int> UpdateAsync(T entity, bool isCommit = true, bool isUpdate = true, params Expression<Func<T, object>>[] propertiesToUpdate)
        {
            if (entity == null)
            {
                return Task.Run(() => 0);
            }
            if (propertiesToUpdate.Length <= 0)
            {
                _dbContext.Set<T>().Update(entity);
            }
            else
            {
                var modify = _dbContext.Entry(entity);
                if (isUpdate)
                {
                    _dbContext.Set<T>().Attach(entity);
                }
                else
                {
                    modify.State = EntityState.Modified;
                }
                propertiesToUpdate.ToList().ForEach(p => modify.Property(p).IsModified = isUpdate);
            }
            return isCommit ? _dbContext.SaveChangesAsync() : Task.Run(() => 0);
        }

        /// <summary>
        /// 更新多条记录，同一模型(异步方式)(不建议使用)
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="isCommit">是否提交(默认提交)</param>
        /// <param name="isUpdate">更新方式(默认true),如果传递true，则后面传递的参数更新，如果传递false，则后面传递的参数不更新</param>
        /// <param name="propertiesToUpdate">更新字段</param>
        public Task<int> UpdateListAsync(List<T> lists, bool isCommit = true, bool isUpdate = true, params Expression<Func<T, object>>[] propertiesToUpdate)
        {
            if (lists == null || lists.Count <= 0)
            {
                return Task.Run(() => 0);
            }
            if (propertiesToUpdate.Length <= 0)
            {
                _dbContext.Set<T>().UpdateRange(lists);
            }
            else
            {
                if (isUpdate)
                {
                    foreach (var list in lists)
                    {
                        var modify = _dbContext.Entry(list);
                        _dbContext.Set<T>().Attach(list);
                        propertiesToUpdate.ToList().ForEach(p => modify.Property(p).IsModified = isUpdate);
                    }
                }
                else
                {
                    foreach (var list in lists)
                    {
                        var modify = _dbContext.Entry(list);
                        modify.State = EntityState.Modified;
                        propertiesToUpdate.ToList().ForEach(p => modify.Property(p).IsModified = isUpdate);
                    }
                }
            }
            return isCommit ? _dbContext.SaveChangesAsync() : Task.Run(() => 0);
        }
        #endregion

        #region ====================单查询====================
        /// <summary>
        /// 通过Lambda表达式查询实体(异步方式)
        /// </summary>
        /// <param name="query">查询条件(Lambda表达式)</param>
        /// <param name="ignoreQueryFilters">是否忽略过滤器</param>
        /// <returns></returns>
        public Task<T> GetAsync(Expression<Func<T, bool>> query = null, bool ignoreQueryFilters = false)
        {
            if (ignoreQueryFilters)
            {
                return query == null ? _dbContext.Set<T>().AsNoTracking().IgnoreQueryFilters().FirstOrDefaultAsync()
                    : _dbContext.Set<T>().AsNoTracking().IgnoreQueryFilters().FirstOrDefaultAsync(query);
            }
            else
            {
                return query == null ? _dbContext.Set<T>().AsNoTracking().FirstOrDefaultAsync()
                    : _dbContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(query);
            }
        }

        /// <summary>
        /// 通过Lambda表达式查询实体总数(异步方式)
        /// </summary>
        /// <param name="query">查询条件(Lambda表达式)</param>
        /// <param name="ignoreQueryFilters">是否忽略过滤器</param>
        /// <returns></returns>
        public Task<int> CountAsync(Expression<Func<T, bool>> query = null, bool ignoreQueryFilters = false)
        {
            if (ignoreQueryFilters)
            {
                return query == null ? _dbContext.Set<T>().IgnoreQueryFilters().CountAsync()
                    : _dbContext.Set<T>().IgnoreQueryFilters().CountAsync(query);
            }
            else
            {
                return query == null ? _dbContext.Set<T>().CountAsync()
                    : _dbContext.Set<T>().CountAsync(query);
            }
        }

        /// <summary>
        /// 验证当前条件数据库是否存在数据(异步方式)
        /// </summary>
        /// <param name="query">查询条件(Lambda表达式)</param>
        /// <param name="ignoreQueryFilters">是否忽略过滤器</param>
        /// <returns></returns>
        public Task<bool> IsExistAsync(Expression<Func<T, bool>> query = null, bool ignoreQueryFilters = false)
        {
            if (ignoreQueryFilters)
            {
                return query == null ? _dbContext.Set<T>().IgnoreQueryFilters().AnyAsync()
                    : _dbContext.Set<T>().Where(query).IgnoreQueryFilters().AnyAsync();
            }
            else
            {
                return query == null ? _dbContext.Set<T>().AnyAsync()
                    : _dbContext.Set<T>().Where(query).AnyAsync();
            }
        }

        /// <summary>
        /// 返回IQueryable集合，延时加载数据
        /// </summary>
        /// <param name="query">查询条件(Lambda表达式)</param>
        /// <param name="ignoreQueryFilters">是否忽略过滤器</param>
        /// <returns></returns>
        public IQueryable<T> GetAllAsync(Expression<Func<T, bool>> query = null, bool ignoreQueryFilters = false)
        {
            if (ignoreQueryFilters)
            {
                return query == null ? _dbContext.Set<T>().AsNoTracking().IgnoreQueryFilters()
                    : _dbContext.Set<T>().Where(query).AsNoTracking().IgnoreQueryFilters();
            }
            else
            {
                return query == null ? _dbContext.Set<T>().AsNoTracking()
                    : _dbContext.Set<T>().Where(query).AsNoTracking();
            }
        }
        #endregion

        #region ====================分页查询==================
        /// <summary>
        /// 分页查询，返回IQueryable集合，延迟加载数据(异步加载)，异步加载不能使用out,ref
        /// </summary>
        /// <typeparam name="TEntity">查询条件</typeparam>
        /// <typeparam name="TOrderBy">排序条件</typeparam>
        /// <typeparam name="TResult">返回的实体(给前台相应)</typeparam>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页显示多少条数据</param>
        /// <param name="where">查询条件</param>
        /// <param name="orderExpression">排序</param>
        /// <param name="selector">查询结果</param>
        /// <param name="ignoreQueryFilters">是否忽略过滤器</param>
        /// <returns></returns>
        public IQueryable<T> GetPageAllAsync(int pageIndex, int pageSize, Expression<Func<T, bool>> where = null, string orderExpression = null, bool ignoreQueryFilters = false)
        {
            IQueryable<T> query = _dbContext.Set<T>();
            query = where != null ? query.Where(where) : query;
            // if (!string.IsNullOrEmpty(orderExpression))
            // {
            //     //多字段排序
            //     var orders = orderExpression.Split(',');
            //     if (orders.Length > 0)
            //     {
            //         IOrderedQueryable<T> queryOrdered = query.OrderBy(orders[0]);
            //         for (int i = 1; i < orders.Length; i++)
            //         {
            //             if (!string.IsNullOrEmpty(orders[i]))
            //             {
            //                 queryOrdered = queryOrdered.ThenBy(orders[i]);
            //             }
            //         }
            //         query = queryOrdered;
            //     }
            //     else
            //     {
            //         query = query.OrderBy(orderExpression);
            //     }
            // }
            //分页并且返回查询需要的字段信息返回
            query = query.Skip(pageIndex * pageSize).Take(pageSize);
            return ignoreQueryFilters ? query.AsNoTracking().IgnoreQueryFilters() : query.AsNoTracking();
        }

        #endregion

    }
}