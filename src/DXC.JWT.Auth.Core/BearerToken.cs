namespace DXC.JWT.Auth.Core
{
    public class BearerToken
    {
        public string Token { get; set; }
        public long ExpiresAt { get; set; }
    }
}