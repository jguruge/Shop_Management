using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using ShopManagement.Api.Data;
using ShopManagement.Api.Features.Auth.Services;

namespace ShopManagement.Api.Features.Auth;

public static class AuthModule
{
    public static IServiceCollection AddAuthFeature(this IServiceCollection services, IConfiguration configuration)
    {
        var section = configuration.GetSection(JwtOptions.SectionName);
        services.Configure<JwtOptions>(section);

        var jwt = section.Get<JwtOptions>() ?? new JwtOptions();
        if (string.IsNullOrWhiteSpace(jwt.Key))
            throw new InvalidOperationException("Jwt:Key is not configured. Set Jwt__Key in backend/.env.");

        services.AddSingleton<PasswordHasher>();
        services.AddSingleton<JwtTokenGenerator>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<DbSeeder>();

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.MapInboundClaims = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = jwt.Issuer,
                    ValidateAudience = true,
                    ValidAudience = jwt.Audience,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key)),
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(1),
                    NameClaimType = "unique_name",
                    RoleClaimType = "role"
                };
            });

        services.AddAuthorization();
        return services;
    }
}
