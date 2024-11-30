using AppFinanceiro.AgioBank.Utils.Notifications.Enums;

namespace AppFinanceiro.AgioBank.Utils.Notifications.Common;

public record struct Notification(NotificationType Tipo, NotificationDetail Detalhe);