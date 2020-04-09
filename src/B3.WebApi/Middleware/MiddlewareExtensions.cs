using Microsoft.AspNetCore.Builder;

namespace B3.WebApi.Middleware
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseDevelopmentUser(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<DevelopmentUserMiddleware>();
        }
    }
}