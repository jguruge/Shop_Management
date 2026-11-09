using Microsoft.EntityFrameworkCore;
using ShopManagement.Api.Data;
using ShopManagement.Api.Features.Auth;
using ShopManagement.Api.Features.Products;
using ShopManagement.Api.Features.Shared.Configuration;
using ShopManagement.Api.Features.Shared.Http;

// Optional backend/.env for local runs (backend/.env.example); real environment variables win.
DotEnvFile.Load(Path.Combine(Directory.GetCurrentDirectory(), ".env"));

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAuthFeature(builder.Configuration);
builder.Services.AddProductsFeature();

var allowedOrigins = builder.Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>() ?? [];
builder.Services.AddCors(options =>
{
    options.AddPolicy("Frontend", policy => policy
        .WithOrigins(allowedOrigins)
        .AllowAnyHeader()
        .AllowAnyMethod());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    await scope.ServiceProvider.GetRequiredService<DbSeeder>().SeedAsync();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
else
{
    // In dev the frontend calls the plain-HTTP endpoint; redirecting would break fetch().
    app.UseHttpsRedirection();
}

app.UseCors("Frontend");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
