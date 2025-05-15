namespace KakauDelivery.Domain.Notifications
{
    public class Notifier : INotifier
    {
        private readonly List<Notification> _notifications = new List<Notification>();

        public bool AnyNotification() => _notifications.Any();
        public List<Notification> GetNotifications() => _notifications;
        public void Handle(Notification notificacao) => _notifications.Add(notificacao);
    }
}
