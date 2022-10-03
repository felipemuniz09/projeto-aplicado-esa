using FinancasParaCasais.Application.Interfaces.Notifications;
using System.Net;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace FinancasParaCasais.Api.Middlewares
{
    public class NotificationMiddleware
    {
        private readonly RequestDelegate _next;

        public NotificationMiddleware(RequestDelegate next) => _next = next;

        public async Task InvokeAsync(HttpContext context, INotificationService notificationService)
        {
            await _next(context);

            var notifications = notificationService.GetNotifications();

            if (notifications.Any())
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Response.ContentType = Text.Plain;
                await context.Response.WriteAsync(JsonSerializer.Serialize(notifications));
            }
        }
    }

    public static class NotificationMiddlewareExtensions
    {
        public static IApplicationBuilder UseNotificationMiddleware(this IApplicationBuilder app) => app.UseMiddleware<NotificationMiddleware>();
    }
}
