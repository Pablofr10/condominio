using Microsoft.AspNetCore.Builder;

namespace Condominio.API.Helpers
{
    public static class ExceptionMiddleware
    {
        public static void ConfigureExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<CustomExceptionMiddleware>();
        }
    }
}