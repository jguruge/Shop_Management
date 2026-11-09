using Microsoft.AspNetCore.Mvc;
using ShopManagement.Api.Features.Shared.Exceptions;

namespace ShopManagement.Api.Features.Shared.Http;

public class ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (UnauthorizedException ex)
        {
            await WriteProblem(context, StatusCodes.Status401Unauthorized, ex.Message);
        }
        catch (NotFoundException ex)
        {
            await WriteProblem(context, StatusCodes.Status404NotFound, ex.Message);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Unhandled exception");
            await WriteProblem(context, StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
        }
    }

    private static Task WriteProblem(HttpContext context, int status, string detail)
    {
        context.Response.StatusCode = status;
        return context.Response.WriteAsJsonAsync(new ProblemDetails { Status = status, Detail = detail });
    }
}
