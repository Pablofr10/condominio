using System.Net;
using System.Threading.Tasks;
using Condominio.Application.Exceptions;
using Condominio.Application.Repository;
using Condominio.Domain.Dtos.Response;
using Microsoft.AspNetCore.Http;

namespace Condominio.API.Helpers
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerManager _logger;

        public CustomExceptionMiddleware(RequestDelegate next, ILoggerManager logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (LoginException ex)
            {
                _logger.LogError($"Erro ao realizar login: {ex}");
                await HandleLoginExeptionAsync(httpContext, ex);
            }
        }

        private Task HandleExeptionAsync(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;

            return context.Response.WriteAsync(new ErrosResponse
            {
                StatusCode = context.Response.StatusCode,
                Message = "Erro ao cadastrar usuário."
            }.ToString());
        }
        
        private Task HandleLoginExeptionAsync(HttpContext context, LoginException loginException)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;

            return context.Response.WriteAsync(new ErrosResponse
            {
                StatusCode = context.Response.StatusCode,
                Message = loginException.Message
            }.ToString());
        }
    }
}