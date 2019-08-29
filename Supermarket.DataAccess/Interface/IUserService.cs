using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.Domain.Models;
using Supermarket.Domain.Request;

namespace Supermarket.DataAccess.Interface
{
    public interface IUserService
    {
         List<User> GetUsers();

         Task<int> AddUser(UserRequest userRequest);
    }
}