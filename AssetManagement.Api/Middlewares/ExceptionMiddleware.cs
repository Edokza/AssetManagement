using AssetManagement.Api.Exceptions;
using Azure.Core.Serialization;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text.Json;

namespace AssetManagement.Api.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _env;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                context.Response.ContentType = "application/json";
                int statusCode = ex is AppException appEx? appEx.StatusCode : (int)HttpStatusCode.InternalServerError;

                var response = _env.IsDevelopment() ? new ErrorResponse
                {
                    StatusCode = statusCode,
                    Message = ex.Message,
                    Details = ex.StackTrace
                } : new ErrorResponse
                {
                    StatusCode = statusCode,
                    Message = ex is AppException ? ex.Message : "Internal Server Error"
                };

                var json = JsonSerializer.Serialize(response);

                await context.Response.WriteAsync(json);

            }
        }
    }

    public class ErrorResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string? Details { get; set; }
    }
}
