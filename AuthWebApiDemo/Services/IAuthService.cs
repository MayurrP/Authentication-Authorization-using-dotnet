using AuthWebApiDemo.Model;
using AuthWebApiDemo.Entites;

namespace AuthWebApiDemo.Services
{
    public interface IAuthService
    {
        Task<User?> Register(UserDto request);

        Task<string> Login(UserDto request);
    }
}