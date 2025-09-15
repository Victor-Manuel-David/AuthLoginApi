using AuthServer.Application.Auth;
using AuthServer.Domain.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Shared.Contracts.Login;

namespace AuthServer.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
    private readonly IUserRepository _users;
    private readonly IAuthService _auth;

    public AuthController(IUserRepository users, IAuthService auth)
    {
        _users = users;
        _auth = auth;
    }

    [HttpPost("login")]
    public ActionResult<LoginResponse> Login([FromBody] LoginRequest request)
    {
        var user = _users.FindByUsername(request.Username);
        if (user is null) return Unauthorized();

        try
        {
            var result = _auth.Login(user, request.Username, request.Password);
            return Ok(new LoginResponse(result.AccessToken, result.ExpiresInSeconds));
        }
        catch
        {
            return Unauthorized();
        }
    }
}
