using System.IdentityModel.Tokens.Jwt;

namespace School.Middleware
{
    public class JWTokenmiddleware
    {
        
        private readonly RequestDelegate _next;
        public JWTokenmiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var tokens = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();


            if (tokens != null)
            {
                var jwthandler = new JwtSecurityTokenHandler();
                var jwtTokens = jwthandler.ReadToken(tokens) as JwtSecurityToken;

                if (jwtTokens != null)
                {
                    var exptime = jwtTokens.Claims.FirstOrDefault(c => c.Type == "exp")?.Value;
                    if (long.TryParse(exptime, out var exp))
                    {
                        var expirationTime = DateTimeOffset.FromUnixTimeSeconds(exp).UtcDateTime;
                        if (expirationTime < DateTime.UtcNow)
                        {
                            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                            await context.Response.WriteAsync("Token has expired");

                            Console.WriteLine("token expired");
                            return;
                        }
                    }
                }
            }
            await _next(context);
        }
    }
}
    

