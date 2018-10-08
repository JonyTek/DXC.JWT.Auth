using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace DXC.JWT.Auth.Core
{
    public class SigningKey
    {
        public static SymmetricSecurityKey Value =>
            new SymmetricSecurityKey(
                Encoding.ASCII.GetBytes(
                    AuthenticationConfiguration.SecurityKey)
            );
    }
}