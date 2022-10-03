using FinancasParaCasais.Application.Interfaces.Notifications;
using System.Net;
using System.Text.Json;

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
                /*var stream = new MemoryStream();
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, notifications);*/

                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync(JsonSerializer.Serialize(notifications));
            }
            
        }
    }

    public static class NotificationMiddlewareExtensions
    {
        public static IApplicationBuilder UseNotificationMiddleware(this IApplicationBuilder app) => app.UseMiddleware<NotificationMiddleware>();
    }
}
