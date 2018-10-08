using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace DXC.JWT.Auth.Core
{
    public static class ServiceCollectionExtensions
    {
        public static void AddJwtAuthentication(this IServiceCollection services)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = SigningKey.Value,

                ValidateIssuer = true,
                ValidIssuer = AuthenticationConfiguration.Issuer,

                ValidateAudience = true,
                ValidAudience = AuthenticationConfiguration.Audience,

                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };

            var builder = services.AddAuthentication(config =>
            {
                config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            });

            builder.AddJwtBearer(options => { options.TokenValidationParameters = tokenValidationParameters; });
        }
    }
}