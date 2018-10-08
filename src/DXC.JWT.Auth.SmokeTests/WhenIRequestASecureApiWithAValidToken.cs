using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using JustBehave;
using Shouldly;
using Xunit;

namespace DXC.JWT.Auth.SmokeTests
{
    public class WhenIRequestASecureApiWithAValidToken : XAsyncBehaviourTest<Api>
    {
        private string email;
        private string password;

        private HttpStatusCode statusCode;

        protected override void Given()
        {
            email = "jonathontek@gmail.com";
            password = "p@ssw0rd";
        }

        protected override async Task When()
        {
            statusCode = await SystemUnderTest.RequestSecureEndpointWithValidToken(email, password);
        }

        [Fact]
        public void WeShouldReceiveA200FromTheEndpoint()
        {
            statusCode.ShouldBe(HttpStatusCode.OK);
        }
    }
}
