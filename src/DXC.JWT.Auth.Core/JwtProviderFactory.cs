namespace DXC.JWT.Auth.Core
{
    public static class JwtProviderFactory
    {
        public static JwtProvider Create()
        {
            return new JwtProvider(
                new TokenProviderOptions(
                    new Identity(new UserRepository()))
            );
        }
    }
}