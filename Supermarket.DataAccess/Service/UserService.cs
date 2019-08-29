using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Supermarket.DataAccess.Data;
using Supermarket.DataAccess.Interface;
using Supermarket.DataAccess.Tools;
using Supermarket.Domain.Models;
using Supermarket.Domain.Request;

namespace Supermarket.DataAccess.Service
{
    public class UserService : BaseService, IUserService
    {
        public UserService(IRepositoryFactory repositoryFactory, SupermarketContext dbContext) : base(repositoryFactory, dbContext)
        {
        }

        public List<User> GetUsers()
        {
            var service = this.CreateService<User>();          
            return service.GetAllAsync().ToList();
        }

        public async Task<int> AddUser(UserRequest userRequest)
        {
            var service = this.CreateService<User>();      
            var user = userRequest.MapTo<User>();
            user.Id = Guid.NewGuid().ToString("N");
            user.Password = DESEncryptHelper.Encrypt(user.Password);
            user.CreateTime = DateTime.Now;
            
            return await service.AddAsync(user);
        }
    }
}