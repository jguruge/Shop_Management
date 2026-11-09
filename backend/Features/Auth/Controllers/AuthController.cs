using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopManagement.Api.Features.Auth.Services;
using ShopManagement.Api.Features.Auth.DTOs;

namespace ShopManagement.Api.Features.Auth.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IAuthService authService) : ControllerBase
{
    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<ActionResult<LoginResponse>> Login(LoginRequest request, CancellationToken ct) =>
        Ok(await authService.LoginAsync(request, ct));

    [HttpGet("me")]
    [Authorize]
    public async Task<ActionResult<UserDto>> Me(CancellationToken ct)
    {
        if (!int.TryParse(User.FindFirst(JwtRegisteredClaimNames.Sub)?.Value, out var userId))
            return Unauthorized();

        return Ok(await authService.GetCurrentUserAsync(userId, ct));
    }
}
