using AppFinanceiro.AgioBank.Utils.Notifications.Common;
using AppFinanceiro.AgioBank.Utils.Notifications.Enums;
using AppFinanceiro.AgioBank.Utils.Notifications.Interfaces;

namespace AppFinanceiro.AgioBank.Utils.Notifications;

public class NotificationContext : INotificationContext
{
    private List<Notification> _notifications = [];
    private IReadOnlyList<Notification> Notifications => _notifications;
    
    public bool HasNotifications() 
        => Notifications.Count > default(int);

    public IReadOnlyList<Notification> GetNotifications() 
        => Notifications;

    public void AddNotification(NotificationType tipo, string mensagem) 
        => _notifications.Add(new Notification(tipo, new NotificationDetail(string.Empty, mensagem)));

    public void AddNotification(NotificationType tipo, string key, string mensagem) 
        => _notifications.Add(new Notification(tipo, new NotificationDetail(key, mensagem)));
}