using System.Security.Claims;
using JustBehave;
using Moq;
using Shouldly;
using Xunit;

namespace DXC.JWT.Auth.Core.Specs.JwtProvider
{
    public class WhenILoginWithValidCredentials : XBehaviourTest<Core.JwtProvider>
    {
        private string email;
        private string password;

        private BearerToken bearerToken;

        private readonly Mock<IIdentity> identity = new Mock<IIdentity>();

        protected override Core.JwtProvider CreateSystemUnderTest()
        {
            identity.Setup(x => x.Resolve(email, password)).Returns(new ClaimsIdentity());

            return new Core.JwtProvider(new TokenProviderOptions(), identity.Object);
        }

        protected override void Given()
        {
            email = "jonathontek@gmail.com";
            password = "p@ssw0rd";
        }

        protected override void When()
        {
            bearerToken = SystemUnderTest.CreateToken(email, password);
        }

        [Fact]
        public void ShouldHaveAValidToken()
        {
            bearerToken.ShouldNotBeNull();
            bearerToken.Token.ShouldNotBeNullOrWhiteSpace();
        }
    }
}
