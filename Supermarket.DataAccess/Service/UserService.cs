using Supermarket.DataAccess.Data;
using Supermarket.DataAccess.Interface;
using Supermarket.DataAccess.Tools;
using Supermarket.Domain.Models;
using Supermarket.Domain.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.DataAccess.Service
{
    public class UserService : BaseService, IUserService
    {
        private readonly IRepository<User> repository;
        public UserService(IRepositoryFactory repositoryFactory, SupermarketContext dbContext) : base(repositoryFactory, dbContext)
        {
            this.repository = this.CreateService<User>();
        }

        public User GetUser(string id)
        {
            return repository.GetAsync(m=>m.Id == id).Result;
        }

        public List<User> GetAllUsers()
        {
            //var service = this.CreateService<User>();          
            return repository.GetAllAsync().ToList();
        }

        public async Task<int> AddUser(UserRequest userRequest)
        {
            var service = this.CreateService<User>();      
            var user = userRequest.MapTo<User>();
            user.Id = Guid.NewGuid().ToString("N");
            //user.Password = DESEncryptHelper.Encrypt(user.Password);
            user.CreateTime = DateTime.Now;
            
            return await service.AddAsync(user);
        }

        
    }
}