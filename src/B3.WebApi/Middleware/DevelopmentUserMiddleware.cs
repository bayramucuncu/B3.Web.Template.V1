using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace B3.WebApi.Middleware
{
    public class DevelopmentUserMiddleware
    {
        private readonly RequestDelegate _next;

        public DevelopmentUserMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            context.Request.HttpContext.User = new ClaimsPrincipal(
                new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, "15cc7127-a31c-418b-b580-27379136b148"),
                    new Claim(ClaimTypes.Name, "Some One")
                }));
            
            await _next(context);
        }
    }
}