using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OlmsApp.Interfaces;

namespace OlmsApp.ActionFilter;

public class AuthorizeActionFilter(IAuthService authService) : IActionFilter
{
    private readonly IAuthService _authService = authService;

    public void OnActionExecuting(ActionExecutingContext context)
    {
        var actionName = context.ActionDescriptor.RouteValues["action"];
        if (actionName is "Login" or "Register") return;
        if (!context.HttpContext.Request.Headers.TryGetValue("Token", out var tokenValue))
        {
            context.Result = new UnauthorizedObjectResult("Token is missing");
            return;
        }
        if (!Guid.TryParse(tokenValue, out var token))
        {
            context.Result = new UnauthorizedObjectResult("Invalid token format");
            return;
        }
        var result = _authService.IsValidToken(token);
        if (!result.IsSuccess)
        {
            context.Result = new UnauthorizedObjectResult(result.Message);
            return;
        }
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
    }
}