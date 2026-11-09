using Microsoft.EntityFrameworkCore;
using ShopManagement.Api.Domain;
using ShopManagement.Api.Features.Auth.Services;

namespace ShopManagement.Api.Data;

// Creates the first admin account (Seed:AdminPassword) when the Users table is empty.
public class DbSeeder(AppDbContext db, PasswordHasher passwordHasher, IConfiguration configuration)
{
    public async Task SeedAsync(CancellationToken ct = default)
    {
        if (await db.Users.AnyAsync(ct))
            return;

        var password = configuration["Seed:AdminPassword"];
        if (string.IsNullOrWhiteSpace(password))
            return;

        db.Users.Add(new User
        {
            Username = "admin",
            Email = configuration["Seed:AdminEmail"] ?? "admin@shop.local",
            FullName = "System Administrator",
            PasswordHash = passwordHasher.Hash(password),
            RoleId = 1
        });
        await db.SaveChangesAsync(ct);
    }
}
