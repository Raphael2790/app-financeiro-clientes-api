using AppFinanceiro.AgioBank.Utils.Notifications.Interfaces;

namespace AppFinanceiro.AgioBank.Utils.Notifications.Extensions;

public static class NotificationContextExtensions
{
    public static string[] GetMessagesFromContext(this INotificationContext notificationContext) 
        => notificationContext.GetNotifications()
            .Select(n => n.Detalhe)
            .Select(d => d.Message).ToArray();
}