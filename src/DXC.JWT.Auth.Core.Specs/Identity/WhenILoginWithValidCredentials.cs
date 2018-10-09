using System;
using System.Linq;
using System.Security.Claims;
using JustBehave;
using Moq;
using Shouldly;
using Xunit;

namespace DXC.JWT.Auth.Core.Specs.Identity
{
    public class WhenILoginWithValidCredentials : XBehaviourTest<Core.Identity>
    {
        private string email;
        private string password;

        private ClaimsIdentity identity;

        private readonly Mock<IUserRepository> userRepository = new Mock<IUserRepository>();

        protected override Core.Identity CreateSystemUnderTest()
        {
            userRepository.Setup(x => x.FindUserBy(email)).Returns(new User
            {
                Id = Guid.Parse("e54dd29d-8cc4-447e-8e9b-ead0c5a5fd85"),
                Email = "jonathontek@gmail.com",
                Password = "p@ssw0rd",
                Fullname = "Jonathan Swieboda"
            });

            return new Core.Identity(userRepository.Object);
        }

        protected override void Given()
        {
            email = "jonathontek@gmail.com";
            password = "p@ssw0rd";
        }

        protected override void When()
        {
            identity = SystemUnderTest.Resolve(email, password);
        }

        [Fact]
        public void ShouldHaveAValidIdentity()
        {
            identity.ShouldNotBeNull();
        }

        [Fact]
        public void ShouldHaveClaimContainingTheFullName()
        {
            var claim = identity.Claims.FirstOrDefault(x => x.Type.Equals("fn"));

            claim.ShouldNotBeNull();
            claim.Value.ShouldBe("Jonathan Swieboda");
        }

        [Fact]
        public void ShouldHaveClaimContainingTheId()
        {
            var claim = identity.Claims.FirstOrDefault(x => x.Type.Equals("id"));

            claim.ShouldNotBeNull();
            claim.Value.ShouldBe("e54dd29d-8cc4-447e-8e9b-ead0c5a5fd85");
        }
        [Fact]
        public void ShouldHaveClaimContainingTheEmail()
        {
            var claim = identity.Claims.FirstOrDefault(x => x.Type.Equals("email"));

            claim.ShouldNotBeNull();
            claim.Value.ShouldBe("jonathontek@gmail.com"); 
        }
    }
}
