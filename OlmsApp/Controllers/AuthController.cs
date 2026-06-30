using Microsoft.AspNetCore.Mvc;
using OlmsApp.DTOs;
using OlmsApp.Interfaces;

namespace OlmsApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IAuthService authService) : ControllerBase
{
    private readonly IAuthService _authService = authService;

    [HttpPost("Register")]
    public IActionResult Register([FromBody] UserDto user)
    {
        var result = _authService.Register(user);
        return !result.IsSuccess ? BadRequest(result.Message) : Ok(result);
    }

    [HttpPost("Login")]
    public IActionResult Login([FromBody] UserDto user)
    {
        var result  = _authService.Login(user);
        return !result.IsSuccess ? Unauthorized(result.Message) : Ok(result);
    }
}
