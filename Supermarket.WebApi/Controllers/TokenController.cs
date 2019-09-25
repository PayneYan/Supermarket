using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Supermarket.DataAccess.Interface;
using Supermarket.DataAccess.Token;
using Supermarket.DataAccess.Tools;
using Supermarket.Domain.Request;

namespace Supermarket.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private ITokenHelper tokenHelper = null;
        private readonly IUserService _userService;

        public TokenController(ITokenHelper _tokenHelper, IUserService userService)
        {
            tokenHelper = _tokenHelper;
            this._userService = userService;
        }

        [HttpGet]
        public IActionResult Get(string id,string pwd)
        {

            var user = _userService.GetUser(id);
            
            if (null != user && user.Password.Equals(pwd))
            {
                return Ok(tokenHelper.CreateToken(user));
            }
            return BadRequest();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Post()
        {
            return Ok(tokenHelper.RefreshToken(Request.HttpContext.User));
        }
    }
}