using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;

namespace DXC.JWT.Auth.Core
{
    public class Identity : IIdentity
    {
        private readonly IUserRepository userRepository;

        public Identity(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public ClaimsIdentity Resolve(string email, string password)
        {
            var user = userRepository.FindUserBy(email);

            if (user == null || !password.Equals(user.Password))
            {
                throw new UnknownUserException();
            }

            var claims = new[]
            {
                new Claim("fn", user.Fullname),
                new Claim("id", user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email)
            };

            return new ClaimsIdentity(new GenericIdentity(email, "Token"), claims);
        }
    }
}