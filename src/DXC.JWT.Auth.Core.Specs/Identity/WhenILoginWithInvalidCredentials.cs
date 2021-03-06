using System.Security.Claims;
using JustBehave;
using Moq;
using Shouldly;
using Xunit;

namespace DXC.JWT.Auth.Core.Specs.Identity
{
    public class WhenILoginWithInvalidCredentials : XBehaviourTest<Core.Identity>
    {
        private string email;
        private string password;

        private ClaimsIdentity identity;

        private readonly Mock<IUserRepository> userRepository = new Mock<IUserRepository>();

        protected override Core.Identity CreateSystemUnderTest()
        {
            userRepository.Setup(x => x.FindUserBy(email)).Returns((User) null);

            return new Core.Identity(userRepository.Object);
        }

        protected override void Given()
        {
            email = "someunknownwmail@gmail.com"; 
            password = "p@ssw0rd";

            RecordAnyExceptionsThrown();
        }

        protected override void When()
        {
            identity = SystemUnderTest.Resolve(email, password);
        }

        [Fact]
        public void ShouldThrowAnException()
        {
            ThrownException.ShouldBeOfType<UnknownUserException>();
        }

        [Fact]
        public void ShouldNotReceiveAnIdentity()
        {
            identity.ShouldBeNull();
        }
    }
}