using System.Net;
using System.Threading.Tasks;
using DXC.JWT.Auth.Core;
using RestSharp;

namespace DXC.JWT.Auth.SmokeTests
{
    public class Api
    {
        public async Task<HttpStatusCode> RequestSecureEndpointWithoutToken()
        {            
            return await MakeGetRequestTo("api/security/secure", null);
        }

        public async Task<HttpStatusCode> RequestSecureEndpointWithValidToken(string username, string password)
        {
            var token = GenerateToken(username, password);
            return await MakeGetRequestTo("api/security/secure", token);
        }

        private static async Task<HttpStatusCode> MakeGetRequestTo(string endpoint, BearerToken token)
        {
            var client = new RestClient("http://localhost:31316");
            var request = new RestRequest(endpoint, Method.GET);
            request.AddParameter("Authorization", $"Bearer {token?.Token}",
                ParameterType.HttpHeader);

            var taskCompletion = new TaskCompletionSource<IRestResponse>();
            client.ExecuteAsync(request, r => taskCompletion.SetResult(r));

            return ((RestResponse) (await taskCompletion.Task)).StatusCode;
        }

        private static BearerToken GenerateToken(string username, string password)
        {
            var provider = JwtProviderFactory.Create();
            var token = provider.CreateToken(username, password);
            return token;
        }
    }
}