using AuthService.Services;
using IdentityService.DTO;
using IdentityService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly TokenService _tokenService;

    public AuthController(TokenService tokenService)
    {
        _tokenService = tokenService;
    }

    [HttpPost("login")]
    public IActionResult Login(LoginDTO dto)
    {
        if (dto.Email != "admin@logi.com" || dto.Password != "1234")
            return Unauthorized();

        var user = new ApplicationUser
        {
            Id = "1",
            Email = dto.Email
        };

        var roles = new List<string> { "Manager" };

        var token = _tokenService.CreateToken(user, roles);

        return Ok(new { access_token = token });
    }
}