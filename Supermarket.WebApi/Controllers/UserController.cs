using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Supermarket.DataAccess.Interface;
using Supermarket.Domain.Models;
using Supermarket.Domain.Request;

namespace Supermarket.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            this._userService = userService;
        }
        // GET api/user
        [HttpGet]
        [AllowAnonymous]
        public ActionResult<List<User>> Get()
        {
            return _userService.GetUsers();
        }

        // POST api/user
        [HttpPost]
        public async Task<int> Post([FromBody]UserRequest user)
        {
            return await _userService.AddUser(user);
        }
    }
}