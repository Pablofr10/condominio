using System;
using System.Net;
using System.Threading.Tasks;
using Condominio.Application.Exceptions;
using Condominio.Domain.Dtos.Response;
using Condominio.Domain.Interfaces.Repository;
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
            catch (Exception ex)
            {
                if (ex is LoginException)
                {
                    _logger.LogError($"Erro ao realizar login: {ex}");
                    await HandleLoginExeptionAsync(httpContext, ex);
                }

                if (ex is PermissaoException)
                {
                    _logger.LogError($"Erro ao realizar login: {ex}");
                    await HandlePermissaoExeptionAsync(httpContext, ex);
                }
                
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
        
        private Task HandleLoginExeptionAsync(HttpContext context, Exception loginException)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;

            return context.Response.WriteAsync(new ErrosResponse
            {
                StatusCode = context.Response.StatusCode,
                Message = loginException.Message
            }.ToString());
        }
        
        private Task HandlePermissaoExeptionAsync(HttpContext context, Exception loginException)
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