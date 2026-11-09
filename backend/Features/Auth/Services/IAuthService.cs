using ShopManagement.Api.Features.Auth.DTOs;

namespace ShopManagement.Api.Features.Auth.Services;

public interface IAuthService
{
    Task<LoginResponse> LoginAsync(LoginRequest request, CancellationToken ct = default);
    Task<UserDto> GetCurrentUserAsync(int userId, CancellationToken ct = default);
}
