using AuthWebApiDemo.Model;
using AuthWebApiDemo.Entites;

namespace AuthWebApiDemo.Services;

public interface IAuthService
{
    Task<User?> Register(UserDto request);

    Task<TokenResponseDto?> Login(UserDto request);

    Task<TokenResponseDto?> RefreshTokenAsync(RefreshTokenRequestDto request);
}