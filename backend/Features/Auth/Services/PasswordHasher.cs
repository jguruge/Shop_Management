using Microsoft.AspNetCore.Identity;
using ShopManagement.Api.Domain;

namespace ShopManagement.Api.Features.Auth.Services;

public class PasswordHasher
{
    private readonly PasswordHasher<User> _hasher = new();

    public string Hash(string password) => _hasher.HashPassword(null!, password);

    public bool Verify(string passwordHash, string password) =>
        !string.IsNullOrEmpty(passwordHash) &&
        _hasher.VerifyHashedPassword(null!, passwordHash, password) != PasswordVerificationResult.Failed;
}
