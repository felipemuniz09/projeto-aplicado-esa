using FinancasParaCasais.Application.Interfaces.Notifications;
using Flunt.Notifications;

namespace FinancasParaCasais.Application.Notifications
{
    public class NotificationService : INotificationService
    {
        private readonly List<Notification> _notifications;

        public NotificationService() => _notifications = new List<Notification>();

        public void AddNotification(Notification notification) => _notifications.Add(notification);

        public IReadOnlyCollection<Notification> GetNotifications() => _notifications;
    }
}
