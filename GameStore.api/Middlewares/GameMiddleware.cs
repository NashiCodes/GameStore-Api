#region

using System.Text.Json;
using GameStore.api.Entities;

#endregion

namespace GameStore.api.Middlewares;

public class GameMiddleware : IMiddleware
{
    public Task InvokeAsync(HttpContext context, RequestDelegate next) {
        var endpoint = context.Request.RouteValues["endpoint"]?.ToString();
        if (endpoint is not null && !endpoint.Equals("games")) {
            context.Response.StatusCode = 404;
            return context.Response.WriteAsync("Endpoint not found");
        }

        var method = context.Request.Method;
        if (method.Equals("POST") || method.Equals("PUT")) {
            var contentType = context.Request.ContentType;
            if (Equals(contentType, "application/json")) {
                var body = context.Request.Body;
                var reader = new StreamReader(body);
                var json = reader.ReadToEnd();
                var game = JsonSerializer.Deserialize<Game>(json);
                try {
                    game?.Validate();
                }
                catch (Exception e) {
                    context.Response.StatusCode = 400;
                    return context.Response.WriteAsync(e.Message);
                }

                return next(context);
            }

            context.Response.StatusCode = 400;
            return context.Response.WriteAsync("Content-Type header value must be application/json");
        }

        return next(context);
    }
}