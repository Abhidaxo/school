namespace School.Controllers.Middleware
{

    public class LoggerMiddleware
    {
        private readonly RequestDelegate _next;
        public LoggerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine($"REQUEST METHOD: {context.Request.Method} REQUEST PATH:{context.Request.Path} user:{context.Connection.RemoteIpAddress} ");
            await _next(context);
        }
    }

}
