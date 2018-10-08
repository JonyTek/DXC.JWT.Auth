using System.Net;
using System.Threading.Tasks;
using JustBehave;
using Shouldly;
using Xunit;

namespace DXC.JWT.Auth.SmokeTests
{
    public class WhenIRequestASecureApiWithAnInvalidToken : XAsyncBehaviourTest<Api>
    {
        private HttpStatusCode statusCode;

        protected override void Given()
        {
        }

        protected override async Task When()
        {
            statusCode = await SystemUnderTest.RequestSecureEndpointWithoutToken();
        }

        [Fact]
        public void WeShouldReceiveA401FromTheEndpoint()
        {
            statusCode.ShouldBe(HttpStatusCode.Unauthorized);
        }
    }
}