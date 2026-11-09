using System.ComponentModel.DataAnnotations;

namespace ShopManagement.Api.Features.Auth.DTOs;

public record LoginRequest([Required] string UsernameOrEmail, [Required] string Password);

public record UserDto(int Id, string Username, string Email, string FullName, string Role);

public record LoginResponse(string AccessToken, DateTime ExpiresAt, UserDto User);
