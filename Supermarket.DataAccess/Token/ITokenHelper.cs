using Supermarket.Domain.Models;
using System.Security.Claims;

namespace Supermarket.DataAccess.Token
{
    public interface ITokenHelper
    {
        ComplexToken CreateToken(User user);
        ComplexToken CreateToken(Claim[] claims);
        Token RefreshToken(ClaimsPrincipal claimsPrincipal);
    }
}