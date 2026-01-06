using AuthWebApiDemo.Entites;
using AuthWebApiDemo.Model;
using AuthWebApiDemo.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthWebApiDemo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService authService;

    public AuthController(IAuthService authService)
    {
        this.authService = authService;
    }

    [HttpPost("register")]
    public async Task<ActionResult<User?>> Register(UserDto request)
    {
        var user = await authService.Register(request);
        if (user is null)
            return BadRequest("User already exists!");

        return Ok(user);
    }

    [HttpPost("login")]
    public async Task<ActionResult<string>> Login(UserDto request)
    {
        string token = await authService.Login(request);
        if (token is null)
            return BadRequest("Invalid username or password.");

        return Ok(token);
    }

    [HttpGet("Auth-endpoint")]
    [Authorize]
    public ActionResult AuthCheck()
    {
        return Ok();
    }
}