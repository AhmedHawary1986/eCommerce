using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace UserService.API.MiddleWares
{
    public class JsonBodyExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public JsonBodyExceptionMiddleware(RequestDelegate next) => _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context).ConfigureAwait(false);
            }
            catch (JsonException ex)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.ContentType = "application/problem+json";

                var errors = new Dictionary<string, string[]>
                {
                    // keep key consistent with validation responses; clients can treat this like a validation error
                    ["RequestBody"] = new[] { ex.Message }
                };

                var payload = new
                {
                    type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                    title = "Invalid JSON payload.",
                    status = StatusCodes.Status400BadRequest,
                    errors
                };

                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                await context.Response.WriteAsync(JsonSerializer.Serialize(payload, options)).ConfigureAwait(false);
            }
        }
    }
}