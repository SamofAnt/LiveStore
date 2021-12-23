namespace LiveStore.Middleware;

public class ResponseLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestLoggingMiddleware> _logger;
    
    public ResponseLoggingMiddleware(RequestDelegate next,                                                                                                              
        ILogger<RequestLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }
    public async Task InvokeAsync(HttpContext context)
    {
        _logger.LogInformation("Request headers: {@Headers}", context.Response.Headers);
        await _next(context);
    }
}