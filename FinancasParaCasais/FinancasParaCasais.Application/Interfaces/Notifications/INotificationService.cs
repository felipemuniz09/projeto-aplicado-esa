using Flunt.Notifications;

namespace FinancasParaCasais.Application.Interfaces.Notifications
{
    public interface INotificationService
    {
        void AddNotification(Notification notification);
        IReadOnlyCollection<Notification> GetNotifications();
    }
}
