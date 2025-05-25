namespace GSCollect_MVC.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var start = DateTime.UtcNow;
            
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unhandled exception occurred during request processing");
                
                // Redirect to login if session expired (similar to old app behavior)
                if (context.Response.StatusCode == 500 && !context.Session.Keys.Any())
                {
                    context.Response.Redirect("/Auth/Login");
                    return;
                }
                
                throw;
            }
            finally
            {
                var elapsed = DateTime.UtcNow - start;
                _logger.LogInformation("Request {Method} {Path} completed in {ElapsedMs}ms with status {StatusCode}",
                    context.Request.Method,
                    context.Request.Path,
                    elapsed.TotalMilliseconds,
                    context.Response.StatusCode);
            }
        }
    }
}
