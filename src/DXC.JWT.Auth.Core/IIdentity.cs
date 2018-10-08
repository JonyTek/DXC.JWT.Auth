using System.Security.Claims;

namespace DXC.JWT.Auth.Core
{
    public interface IIdentity
    {
        ClaimsIdentity Resolve(string email, string password);
    }
}