using Domain.Core.Notifications;
using MediatR;

namespace In.Notification;

public class DomainNotificationDTO(string key, string value) : DomainNotification(key, value), INotification;