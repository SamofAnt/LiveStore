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
        var originalBody = context.Response.Body;
        using (var memStream = new MemoryStream())
        {
            context.Response.Body = memStream;
            await _next(context);
            _logger.LogInformation("Response headers: {@Headers}", context.Response.Headers);

            memStream.Position = 0;
            var responseBody = await new StreamReader(memStream).ReadToEndAsync();
            _logger.LogInformation("Response body: {@Body}", responseBody);
            memStream.Position = 0;
            await memStream.CopyToAsync(originalBody);
        }
    }
}