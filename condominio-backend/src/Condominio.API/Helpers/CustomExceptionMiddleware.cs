using System;
using System.Net;
using System.Threading.Tasks;
using Condominio.Domain.Dtos.Response;
using Condominio.Interface.Repository;
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
                _logger.LogError($"Ocorreu um erro: {ex}");
                await HandleExeptionAsync(httpContext);
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
    }
}