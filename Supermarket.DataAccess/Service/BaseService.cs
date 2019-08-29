using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Supermarket.DataAccess.Data;
using Supermarket.DataAccess.Interface;

namespace Supermarket.DataAccess.Service
{
    public class BaseService : IBaseService
    {
        private readonly IRepositoryFactory _repositoryFactory;
        private readonly SupermarketContext _dbContext;
        public BaseService(IRepositoryFactory repositoryFactory, SupermarketContext dbContext)
        {
            this._dbContext = dbContext;
            this._repositoryFactory = repositoryFactory;

        }

        public IRepository<T> CreateService<T>() where T : class, new()
        {
            return _repositoryFactory.CreateRepository<T>(_dbContext);
        }
    }
}