namespace KakauDelivery.Domain.Notifications
{
    public interface INotifier
    {
        bool AnyNotification();
        List<Notification> GetNotifications();
        void Handle(Notification notificacao);
    }
}
