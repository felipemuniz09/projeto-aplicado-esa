using Flunt.Notifications;

namespace FinancasParaCasais.Application.Interfaces.Notifications
{
    public interface INotificationService
    {
        void AddNotifications(Notifiable<Notification> notifiable);
        IReadOnlyCollection<Notification> GetNotifications();
    }
}
