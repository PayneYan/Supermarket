using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Supermarket.DataAccess.Interface
{
    public interface IBaseService
    {
        IRepository<T> CreateService<T>() where T :class, new();
    }
}