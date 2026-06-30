using OlmsApp.Interfaces;

namespace OlmsApp.Middlewares;

public class AuthorizeMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task InvokeAsync(HttpContext context, IAuthService authService)
    {
        var endpoint = context.GetEndpoint();
        var endpointName = endpoint?.DisplayName;
        var routeValues = context.Request.RouteValues;
        var controllerName = routeValues["controller"]?.ToString();
        var actionName = routeValues["action"]?.ToString();
        if (actionName is "Login" or "Register")
        {
            await _next(context);
            return;
        }
        if (!context.Request.Headers.TryGetValue("Token", out var tokenValue))
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsync("Token is missing");
            return;
        }
        if (!Guid.TryParse(tokenValue, out var token))
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsync("Invalid token format");
            return;
        }
        var result = authService.IsValidToken(token);
        if (!result.IsSuccess)
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsync(result.Message);
            return;
        }
        Console.WriteLine($"Endpoint: {endpointName}");
        Console.WriteLine($"Controller: {controllerName}");
        Console.WriteLine($"Action: {actionName}");
        await _next(context);
    }
}