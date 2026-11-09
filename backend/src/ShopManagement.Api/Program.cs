using ShopManagement.Api.Extensions;
using ShopManagement.Api.Middleware;
using ShopManagement.Application;
using ShopManagement.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddFrontendCors(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseCors(CorsExtensions.FrontendPolicy);
app.UseAuthorization();
app.MapControllers();

app.Run();
