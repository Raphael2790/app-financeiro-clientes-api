using AppFinanceiro.AgioBank.Utils.Notifications.Common;
using AppFinanceiro.AgioBank.Utils.Notifications.Enums;

namespace AppFinanceiro.AgioBank.Utils.Notifications.Interfaces;

public interface INotificationContext
{
    bool HasNotifications();
    IReadOnlyList<Notification> GetNotifications();
    void AddNotification(NotificationType tipo, string mensagem);
    void AddNotification(NotificationType tipo, string key, string mensagem);
}