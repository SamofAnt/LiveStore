using System.Text;

namespace LiveStore.Middleware;

public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestLoggingMiddleware> _logger;
    
    public RequestLoggingMiddleware(RequestDelegate next,                                                                                                              
        ILogger<RequestLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }
    public async Task InvokeAsync(HttpContext context)
    {

         context.Request.EnableBuffering();
         context.Request.Body.Position = 0;
        var bodyStr = await new StreamReader(context.Request.Body, Encoding.UTF8, true, 1024, true).ReadToEndAsync();
        
        context.Request.Body.Position = 0;   
        _logger.LogInformation("Request headers: {@Headers}", context.Request.Headers);  
        _logger.LogInformation("Request body: {@Body}", bodyStr);
        await _next(context);
    }
}