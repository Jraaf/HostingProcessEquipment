namespace API.Authentication;

public class ApiKeyMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IConfiguration _configuration;

    public ApiKeyMiddleware(RequestDelegate next, IConfiguration configuration)
    {
        _next = next;
        _configuration = configuration;
    }
    public async Task InvokeAsync(HttpContext context)
    {
        if (!context.Request.Headers.TryGetValue(AuthenticationConstants.ApiKeyHeaderName, out var apiKey))
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("ApiKey is missing");
            return;
        }
        var correctKey = _configuration.GetValue<string>(AuthenticationConstants.ApiKeySectionName);
        if (!correctKey.Equals(apiKey))
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("ApiKey is incorrect");
            return;
        }
        await _next(context);
    }
}
