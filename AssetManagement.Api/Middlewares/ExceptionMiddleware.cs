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
                _logger.LogError($"Something went wrong: {ex}");

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                var response = _env.IsDevelopment() ? new ErrorResponse
                {
                    StatusCode = context.Response.StatusCode,
                    Message = ex.Message,
                    Details = ex.StackTrace
                } : new ErrorResponse
                {
                    StatusCode = context.Response.StatusCode,
                    Message = "Internal Server Error from the custom middleware."
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
