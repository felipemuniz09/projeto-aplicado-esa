using FinancasParaCasais.Application.Interfaces.Notifications;
using Flunt.Notifications;

namespace FinancasParaCasais.Application.Notifications
{
    public class NotificationService : INotificationService
    {
        private readonly List<Notification> _notifications;

        public NotificationService() => _notifications = new List<Notification>();

        public void AddNotifications(IReadOnlyCollection<Notification> notifications) => _notifications.AddRange(notifications);

        public IReadOnlyCollection<Notification> GetNotifications() => _notifications;
    }
}
