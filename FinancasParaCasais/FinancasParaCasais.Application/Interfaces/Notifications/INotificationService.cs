using Flunt.Notifications;

namespace FinancasParaCasais.Application.Interfaces.Notifications
{
    public interface INotificationService
    {
        void AddNotifications(IReadOnlyCollection<Notification> notifications);
        IReadOnlyCollection<Notification> GetNotifications();
    }
}
