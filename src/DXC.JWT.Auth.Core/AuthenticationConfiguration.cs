namespace DXC.JWT.Auth.Core
{
    public class AuthenticationConfiguration
    {
        public static int ExpirationHours => 24;
        public static string Issuer => "DXC.JWT.Auth";
        public static string Audience => "DXC.JWT.Auth";
        public static string SecurityKey => "mZt3l4ZA8DxXjyf7Aj4vgpL";
    }
}