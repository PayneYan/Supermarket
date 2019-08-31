using Supermarket.Domain.Models;
using Supermarket.Domain.Request;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Supermarket.DataAccess.Interface
{
    public interface IUserService
    {
        User GetUser(string id);

        List<User> GetAllUsers();

        Task<int> AddUser(UserRequest userRequest);
    }
}