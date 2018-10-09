using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace DXC.JWT.Auth.Core
{
    public class JwtProvider
    {
        private readonly TokenProviderOptions options;
        private readonly IIdentity identity;

        public JwtProvider(TokenProviderOptions options, IIdentity identity)
        {
            this.options = options;
            this.identity = identity;
        }

        public BearerToken CreateToken(string email, string password)
        {
            var now = DateTime.UtcNow;
            var claimsIdentity = identity.Resolve(email, password);
            var expiresAt = new DateTimeOffset(now.Add(options.Expiration))
                .ToUniversalTime()
                .ToUnixTimeSeconds();

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, options.NonceGenerator()),
                new Claim(JwtRegisteredClaimNames.Iat, expiresAt.ToString(),
                    ClaimValueTypes.Integer64)
            }
            .Union(claimsIdentity.Claims);

            var jwt = new JwtSecurityToken(options.Issuer, options.Audience, claims, now, now.Add(options.Expiration),
                options.SigningCredentials);

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new BearerToken {Token = encodedJwt, ExpiresAt = expiresAt};
        }
    }
}