namespace DXC.JWT.Auth.Core
{
    public interface IUserRepository
    {
        User FindUserBy(string email);
    }
}