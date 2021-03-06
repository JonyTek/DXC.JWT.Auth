﻿using System;
using Microsoft.IdentityModel.Tokens;

namespace DXC.JWT.Auth.Core
{
    public class TokenProviderOptions
    {
        public string Issuer => AuthenticationConfiguration.Issuer;
        public string Audience => AuthenticationConfiguration.Audience;

        public TimeSpan Expiration =>
            TimeSpan.FromHours(
                AuthenticationConfiguration.ExpirationHours
            );

        public SigningCredentials SigningCredentials =>
            new SigningCredentials(
                SigningKey.Value, SecurityAlgorithms.HmacSha256
            );

        public Func<string> NonceGenerator => () => Guid.NewGuid().ToString();
    }
}