using AuthWebApiDemo.Entites;
using AuthWebApiDemo.Model;
using AuthWebApiDemo.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthWebApiDemo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController(IAuthService authService) : ControllerBase
{
    [HttpPost("register")]
    public async Task<ActionResult<User?>> Register(UserDto request)
    {
        var user = await authService.Register(request);
        if (user is null)
            return BadRequest("User already exists!");

        return Ok(user);
    }

    [HttpPost("login")]
    public async Task<ActionResult<TokenResponseDto?>> Login(UserDto request)
    {
        TokenResponseDto? token = await authService.Login(request);
        if (token is null)
            return BadRequest("Invalid username or password.");

        return Ok(token);
    }

    [HttpPost("refresh-token")]
    public async Task<ActionResult<TokenResponseDto?>> RefreshToken(RefreshTokenRequestDto request)
    {
        TokenResponseDto? token = await authService.RefreshTokenAsync(request);
        if (token is null)
            return BadRequest("Invalid refresh token.");

        return Ok(token);
    }

    [HttpGet("Auth-endpoint")]
    [Authorize(Roles = "Admin")]
    public ActionResult AdminAuthCheck()
    {
        return Ok();
    }
}