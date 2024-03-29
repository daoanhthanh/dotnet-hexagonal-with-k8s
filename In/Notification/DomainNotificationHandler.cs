using MediatR;

namespace In.Notification;

public class DomainNotificationHandler : INotificationHandler<DomainNotificationDTO>
{
    private List<DomainNotificationDTO> _notifications = new();

    public Task Handle(DomainNotificationDTO message, CancellationToken cancellationToken)
    {
        _notifications.Add(message);

        return Task.CompletedTask;
    }

    public virtual List<DomainNotificationDTO> GetNotifications()
    {
        return _notifications;
    }

    public virtual bool HasNotifications()
    {
        return GetNotifications().Any();
    }

    public void Dispose()
    {
        _notifications = new List<DomainNotificationDTO>();
    }
}
