using Microsoft.AspNetCore.Builder;

namespace RealEstatIdentity.Middlewares
{
    public static class DataSeederMiddlewareExtensions
    {
        public static IApplicationBuilder UseDataseeder(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<DataSeederMiddleware>();
        }
    }
}
