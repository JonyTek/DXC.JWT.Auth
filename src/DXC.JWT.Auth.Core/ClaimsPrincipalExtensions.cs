using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace DXC.JWT.Auth.Core
{
    public static class ClaimsPrincipalExtensions
    {
        public static string Email(this ClaimsPrincipal principal)
        {
            return FindClaimOfType(principal, "em");
        }

        public static string Fullname(this ClaimsPrincipal principal)
        {
            return FindClaimOfType(principal, "fn");
        }

        public static string Id(this ClaimsPrincipal principal)
        {
            return FindClaimOfType(principal, "id");
        }

        private static string FindClaimOfType(ClaimsPrincipal principal, string type)
        {
            return principal.Claims.FirstOrDefault(x => x.Type.Equals(type))?.Value;
        }
    }
}