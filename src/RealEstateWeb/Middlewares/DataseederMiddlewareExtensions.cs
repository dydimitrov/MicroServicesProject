using Microsoft.AspNetCore.Builder;

namespace RealEstateWeb.Middlewares
{
    public static class DataSeederMiddlewareExtensions
    {
        public static IApplicationBuilder UseDataseeder(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<DataSeederMiddleware>();
        }
    }
}
