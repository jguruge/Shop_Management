using Microsoft.EntityFrameworkCore;
using ShopManagement.Api.Data;
using ShopManagement.Api.Domain;
using ShopManagement.Api.Features.Auth.DTOs;
using ShopManagement.Api.Features.Shared.Exceptions;

namespace ShopManagement.Api.Features.Auth.Services;

public class AuthService(
    AppDbContext db,
    PasswordHasher passwordHasher,
    JwtTokenGenerator tokenGenerator) : IAuthService
{
    private const string InvalidCredentials = "Invalid username or password.";

    public async Task<LoginResponse> LoginAsync(LoginRequest request, CancellationToken ct = default)
    {
        var value = request.UsernameOrEmail.Trim().ToLower();
        var user = await db.Users.Include(u => u.Role)
            .FirstOrDefaultAsync(u => u.Username.ToLower() == value || u.Email.ToLower() == value, ct);

        if (user is null || !user.IsActive || !passwordHasher.Verify(user.PasswordHash, request.Password))
            throw new UnauthorizedException(InvalidCredentials);

        user.LastLoginAt = DateTime.UtcNow;
        await db.SaveChangesAsync(ct);

        var (token, expiresAt) = tokenGenerator.Generate(user);
        return new LoginResponse(token, expiresAt, ToDto(user));
    }

    public async Task<UserDto> GetCurrentUserAsync(int userId, CancellationToken ct = default)
    {
        var user = await db.Users.AsNoTracking().Include(u => u.Role).FirstOrDefaultAsync(u => u.Id == userId, ct)
            ?? throw new NotFoundException(nameof(User), userId);
        return ToDto(user);
    }

    private static UserDto ToDto(User u) => new(u.Id, u.Username, u.Email, u.FullName, u.Role.Name);
}
