namespace StudentManager.Middlewares;

public class RequestTimeLoggerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestTimeLoggerMiddleware> _logger;

    public RequestTimeLoggerMiddleware(RequestDelegate next, ILogger<RequestTimeLoggerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var startTime = DateTime.Now;

        // Call the next middleware in the pipeline
        await _next(context);

        var elapsedTime = DateTime.Now - startTime;
        _logger.LogInformation($"[RequestTime] {context.Request.Path} took {elapsedTime.TotalMilliseconds} ms");
    }
}