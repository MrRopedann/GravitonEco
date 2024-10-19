using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace GravitonEcoWeb.Middleware
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomExceptionMiddleware> _logger;

        public CustomExceptionMiddleware(RequestDelegate next, ILogger<CustomExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (SocketException ex)
            {
                _logger.LogError(ex, "SocketException: {Message}", ex.Message);
                // Перенаправляем на страницу настроек
                httpContext.Response.Redirect("/Settings");
            }
            catch (Exception ex)
            {
                // Логируем все остальные исключения
                _logger.LogError(ex, "Unhandled exception: {Message}", ex.Message);
                throw; // Пробрасываем дальше для стандартной обработки
            }
        }
    }
}