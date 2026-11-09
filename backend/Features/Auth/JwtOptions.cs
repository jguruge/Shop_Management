namespace ShopManagement.Api.Features.Auth;

public class JwtOptions
{
    public const string SectionName = "Jwt";

    public string Issuer { get; set; } = "ShopManagement.Api";
    public string Audience { get; set; } = "ShopManagement.Client";
    public string Key { get; set; } = string.Empty;
    public int ExpiryMinutes { get; set; } = 60;
}
